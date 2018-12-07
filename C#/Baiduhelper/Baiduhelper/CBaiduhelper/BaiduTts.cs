using System.Collections.Generic;
using System.IO;

namespace CBaiduhelper
{
    public class BaiduTts
    {
        public static bool Tts(string TXT, string OPath)
        {
            // 设置APPID/AK/SK
            var APP_ID = "14995725";
            var API_KEY = "9j43q4PH3nf1uWhoaoN704FD";
            var SECRET_KEY = "Rh7DAEiOymEZTaCci0pHYIKrhPUqkYfR";

            var ttsClient = new Baidu.Aip.Speech.Tts(API_KEY, SECRET_KEY);
            ttsClient.Timeout = 60000;  // 修改超时时间
            
            // 可选参数
            var option = new Dictionary<string, object>()
            {
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", 4}  // 发音人，4：情感度丫丫童声
            };
            var result = ttsClient.Synthesis(TXT, option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {
                File.WriteAllBytes(OPath, result.Data);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}