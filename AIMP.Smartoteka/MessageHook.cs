namespace AIMP.Smartoteka
{
    using System;
    using SDK;
    using SDK.MessageDispatcher;

    public delegate ActionResultType HookMessage(AimpCoreMessageType message, int param1, IntPtr param2);

    public class MessageHook : IAimpMessageHook
    {
        public AimpActionResult CoreMessage(AimpCoreMessageType message, int param1, IntPtr param2)
        {
            OnCoreMessage?.Invoke(message, param1, param2);
            return new AimpActionResult(ActionResultType.OK);
        }

        public event HookMessage OnCoreMessage;
    }
}