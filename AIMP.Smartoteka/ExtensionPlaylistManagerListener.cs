namespace AIMP.Smartoteka
{
    using SDK;
    using SDK.Playlist;

    public class ExtensionPlaylistManagerListener : IAimpExtension, IAimpExtensionPlaylistManagerListener
    {
        public AimpActionResult OnPlaylistActivated(IAimpPlaylist playlist)
        {
            return new AimpActionResult(ActionResultType.Handle);
        }

        public AimpActionResult OnPlaylistAdded(IAimpPlaylist playlist)
        {
            return new AimpActionResult(ActionResultType.OK);
        }

        public AimpActionResult OnPlaylistRemoved(IAimpPlaylist playlist)
        {
            return new AimpActionResult(ActionResultType.OK);
        }
    }
}