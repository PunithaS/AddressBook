using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AddressBook
{
    public static class FileHelper
    {
        // Write a text file to the app's local folder. 

        public static async Task<string> WriteTextFile(string filename, string contents)
        {

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);

            using (IRandomAccessStream textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
            {

                using (DataWriter textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(contents);
                    await textWriter.StoreAsync();
                }
            }

            return textFile.Path;
        }

        // Read the contents of a text file from the app's local folder.

        public static async Task<string> ReadTextFile(string filename)
        {
            string contents;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.GetFileAsync(filename);

            using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
            {

                using (DataReader textReader = new DataReader(textStream))
                {
                    uint textLength = (uint)textStream.Size;
                    await textReader.LoadAsync(textLength);
                    contents = textReader.ReadString(textLength);
                }

            }

            return contents;
        }

        public static async Task<string> AppendTextFile(string filename, string contents)
        {
            // IEnumerable<String> lines = new List<String>() { contents };
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textfile = await localFolder.GetFileAsync(filename);
            await FileIO.AppendTextAsync(textfile, contents + Environment.NewLine);


            //using (IRandomAccessStream textStream = await
            //   textfile.OpenAsync(FileAccessMode.ReadWrite))
            //{

            //    using (DataWriter textWriter = new DataWriter(textStream))
            //    {
            //        textWriter.WriteString(contents);
            //        await textWriter.StoreAsync();
            //    }
            //}

            return textfile.Path;
        }
    }
}
