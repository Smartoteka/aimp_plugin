namespace AIMP.Smartoteka
{
    using System;
    using System.Windows.Input;
    using SDK;
    using SDK.ActionManager;
    using SDK.MenuManager;

    [AimpPlugin("aimp_smartoteka", "Mikhail Tatarkov", "1", AimpPluginType = AimpPluginType.Addons)]
    public class Program : AimpPlugin
    {
        private SmartotekaForm _smartotkeraForm;
        private MessageHook _hook;

        public override void Initialize()
        {
            var result = Player.Core.CreateObject<IAimpMenuItem>();

            if (result.ResultType == ActionResultType.OK)
            {
                IAimpMenuItem menuItem = result.Result as IAimpMenuItem;
                
                var action = Player.Core.CreateAimpObject<IAimpAction>().Result;
                action.Id = "aimp.Smartoteka.action.1";
                action.Name = "Smartoteka";
                action.GroupName = "Smartoteka";
                action.OnExecute += SmartotekaFormItemOnOnExecute;
                action.DefaultGlobalHotKey = Player.ServiceActionManager.MakeHotkey(
                    ModifierKeys.Shift | ModifierKeys.Control,//Bug приводит к комбинации Alt+Shift+S
                    (uint)KeyInterop.VirtualKeyFromKey(Key.S));
                menuItem.Name = "Smartoteka";
                menuItem.Id = "open_smartoteka";

                menuItem.Action = action;
                menuItem.Shortcut = action.DefaultGlobalHotKey;
                Player.ServiceMenuManager.Add(ParentMenuType.CommonUtilities, menuItem);

                Player.ServiceActionManager.Register(action);
            }

            _hook = new MessageHook();
            Player.ServiceMessageDispatcher.Hook(_hook);

            CreateMenuWithAction();
        }

        private void SmartotekaFormItemOnOnExecute(object sender, EventArgs eventArgs)
        {
            if (_smartotkeraForm==null||_smartotkeraForm.IsDisposed)
            {
                _smartotkeraForm = new SmartotekaForm(Player, _hook);
                _smartotkeraForm.FormClosed += (s, e) =>
                {
                    _smartotkeraForm.Dispose();
                    _smartotkeraForm = null;
                };
            }

            _smartotkeraForm.Show();
        }

        public override void Dispose()
        {
            _smartotkeraForm.Dispose();
            System.Diagnostics.Debug.WriteLine("Dispose");

            Player.ServiceMessageDispatcher.Unhook(_hook);
        }

        private void CreateMenuWithAction()
        {
            var menuItemResult = Player.Core.CreateAimpObject<IAimpMenuItem>();
            if (menuItemResult.ResultType == ActionResultType.OK)
            {
                var action = Player.Core.CreateAimpObject<IAimpAction>().Result;
                action.Id = "aimp.MenuAndActionsSmartoteka.action.1";
                action.Name = "Smartoteka";
                action.OnExecute += (sender, args) =>
                {
                    var item = sender as IAimpAction;
                    //Logger.Instance.AddInfoMessage($"Event: [Execute] {item.Id}");
                };
                Player.ServiceActionManager.Register(action);
            }
        }
    }
}
