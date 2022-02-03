namespace AIMP.Smartoteka
{
    using System;
    using SDK;
    using SDK.Playlist;

    public class AimpPlaylistEventArgs
        :EventArgs {
        public IAimpPlaylist Playlist { get; }

        public AimpPlaylistEventArgs(IAimpPlaylist playlist)
        {
            Playlist = playlist;
        }

    }
    public class ExtensionPlaylistManagerListener : IAimpExtension, IAimpExtensionPlaylistManagerListener
    {
        public event EventHandler<AimpPlaylistEventArgs> Activated;
        public event EventHandler<AimpPlaylistEventArgs> Added;
        public event EventHandler<AimpPlaylistEventArgs> Removed;
        public AimpActionResult OnPlaylistActivated(IAimpPlaylist playlist)
        {
            Activated?.Invoke(this, new AimpPlaylistEventArgs(playlist));
            return new AimpActionResult(ActionResultType.Handle);
        }

        public AimpActionResult OnPlaylistAdded(IAimpPlaylist playlist)
        {
            try
            {
                Added?.Invoke(this, new AimpPlaylistEventArgs(playlist));
                return new AimpActionResult(ActionResultType.OK);
            }
            catch (Exception e)
            {
                return new AimpActionResult(ActionResultType.Fail);
            }
           
        }

        public AimpActionResult OnPlaylistRemoved(IAimpPlaylist playlist)
        {
            try
            {
                Removed?.Invoke(this, new AimpPlaylistEventArgs(playlist));
                return new AimpActionResult(ActionResultType.OK);
            }
            catch (Exception e)
            {
                return new AimpActionResult(ActionResultType.Fail);
            }
        }
    }
}