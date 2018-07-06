using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AddressBook
{
    public static class FileHelper
    {

        // Create a new text file to the app's local folder. 

        public static async Task<string> CreateTextFile(string filename, string contents)
        {

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                var file = await localFolder.GetFileAsync(filename);
                await file.DeleteAsync();
            }
            catch (System.IO.FileNotFoundException)
            {
                //ignore
            }

            return await WriteTextFile(filename, contents);
        }




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
            contents = contents + Environment.NewLine;
            // IEnumerable<String> lines = new List<String>() { contents };
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile textfile = await localFolder.GetFileAsync(filename);
                await FileIO.AppendTextAsync(textfile, contents);
                File.Delete(contents);
                return textfile.Path;
            }
            catch (System.IO.FileNotFoundException)
            {
                // If file not found, we can't append. Hence, create a new file and write.
                return await WriteTextFile(filename, contents);
            }
        }
    }
}
