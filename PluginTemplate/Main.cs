using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using Newtonsoft.Json;


namespace PluginTemplate
{
    [ApiVersion(1, 16)]
    public class PluginTemplate : TerrariaPlugin
    {
        string path = Path.Combine(TShock.SavePath, "PluginTemplate.json");
        Config Config = new Config();
        public override string Name
        {
            get
            {
                return "PluginTemplate";
            }
        }
        public override string Author
        {
            get
            {
                return "Your name here.";
            }
        }
        public override string Description
        {
            get
            {
                return "A description of your plugin goes here.";
            }
        }
        public override Version Version
        {
            get
            {
                return new Version("1.0");
            }
        }
        public PluginTemplate(Main game)
            : base(game)
        {
            Order = 1;
        }
        public override void Initialize()
        {
            ServerApi.Hooks.GameInitialize.Register(this, OnInitialize);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.GameInitialize.Deregister(this, OnInitialize);
            }
            base.Dispose(disposing);
        }
        public void OnInitialize(EventArgs args)
        {
            if (!File.Exists(path))
            {
                Config.Write(path);
            }
            Config = Config.Read(path);
            //add commands here. example:
            Commands.ChatCommands.Add(new Command("permission", CommandName, "commandWithoutSlash"));

        }
        //here is the above command:
        void CommandName(CommandArgs args)
        {
        }
    }
}
