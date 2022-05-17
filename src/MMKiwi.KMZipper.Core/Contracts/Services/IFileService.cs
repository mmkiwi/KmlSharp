// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KMZipper.Core.Contracts.Services;

public interface IFileService
{
    T? Read<T>(string folderPath, string fileName);

    void Save<T>(string folderPath, string fileName, T content);

    void Delete(string folderPath, string fileName);
}
