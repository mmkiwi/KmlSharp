// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Text;

using MMKiwi.KMZipper.Core.Contracts.Services;

using Newtonsoft.Json;

namespace MMKiwi.KMZipper.Core.Services;

public class FileService : IFileService
{
    public T? Read<T>(string folderPath, string fileName)
    {
        string? path = Path.Combine(folderPath, fileName);
        if (File.Exists(path))
        {
            string? json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        throw new FileNotFoundException("Could not open requested file", fileName);
    }

    public void Save<T>(string folderPath, string fileName, T content)
    {
        if (!Directory.Exists(folderPath))
        {
            _ = Directory.CreateDirectory(folderPath);
        }

        string? fileContent = JsonConvert.SerializeObject(content);
        File.WriteAllText(Path.Combine(folderPath, fileName), fileContent, Encoding.UTF8);
    }

    public void Delete(string folderPath, string fileName)
    {
        if (fileName != null && File.Exists(Path.Combine(folderPath, fileName)))
        {
            File.Delete(Path.Combine(folderPath, fileName));
        }
    }
}
