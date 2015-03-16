﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuranXmlTo.Models;

namespace QuranXmlTo.Formatter
{
    /// <summary>
    /// Output a quran into a list of json files based on the chapter.
    /// </summary>
    public class JsonQuranFormatter : FileQuranFormatter
    {        
        public JsonQuranFormatter(string outputDirectory) : base(outputDirectory)
        {
        }


        public override void Format(Quran quran)
        {
            foreach (var chapter in quran.Chapters)
            {
                using (var file = File.Create(Path.Combine(OutputDirectory, chapter.Index + ".json")))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        writer.Write(JsonConvert.SerializeObject(chapter));
                        writer.Flush();
                    }
                }
            }
        }

        public override async Task FormatAsync(Quran quran)
        {
            foreach (var chapter in quran.Chapters)
            {
                using (var file = File.Create(Path.Combine(OutputDirectory, chapter.Index + ".json")))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        await writer.WriteAsync(JsonConvert.SerializeObject(chapter));
                        await writer.FlushAsync();
                    }
                }
            }
        }
    }
}