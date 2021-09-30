﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Oleg_Debug;
using System.Text.Json;


namespace Lab10_lib
{
    public class FileService<T> : IFileService<T> where T : Employee
    {
       public void SaveData(IEnumerable<T> data, string fileName)
        {
            using (FileStream fs = new FileStream(fileName,FileMode.Create))
            {
                var options = new JsonSerializerOptions { IncludeFields = true };
                JsonSerializer.SerializeAsync<List<T>>(fs,data.ToList(),options).Wait();
            }
        }

       public IEnumerable<T> ReadFile(string fileName)
        {
            using (FileStream fs = new FileStream(fileName,FileMode.Open))
            {
                var options = new JsonSerializerOptions { IncludeFields = true };
                var ans = JsonSerializer.DeserializeAsync<List<T>>(fs,options).Result;
               return default;
            }
        }
    }
}