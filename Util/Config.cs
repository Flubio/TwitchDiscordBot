using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDiscordBot.Util
{
    public class Config
    {
        public string Token { get; private set; }

        private readonly string dir;
        private readonly string file;
        public Config()
        {
            dir = Path.Combine("config");
            file = Path.Combine(dir, "config.json");

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public void Load()
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(file))
            {
                Token = "";
                Write();
                return;
            }

            FileStream stream = File.OpenRead(file);

            using (StreamReader reader = new StreamReader(stream))
            {
                ConfigContainer container = JsonConvert.DeserializeObject<ConfigContainer>(reader.ReadToEnd());
                Token = container.Token;
            }
        }

        private void Write()
        {
            ConfigContainer container = new ConfigContainer
            {
                Token = Token
            };

            if (File.Exists(file))
                File.Delete(file);

            FileStream stream = File.OpenWrite(file);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(JsonConvert.SerializeObject(container, Formatting.Indented));
            }
        }

    }

    public class ConfigContainer
    {
        public string Token { get; set; }
    }
}
