using System;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;


namespace Polihack
{
    class GoogleDriveManager
    {
        string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile };

        public DriveService _service;

        public GoogleDriveManager()
        {
                var clientId = "1063291435914-5gmbnrqb81dds1v15n0e3bcbq6uevq85.apps.googleusercontent.com";
                var clientSecret = "w7G8QXA43PsxEgQhSjXE0tpA";

                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                scopes,
                Environment.UserName,
                CancellationToken.None,
                new FileDataStore("Link.Saver.Rpreda")).Result;
                _service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "LinkSaver",
                });
        }

        public Google.Apis.Drive.v2.Data.File uploadFile(string _uploadFile)
        {

            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "Link saver backup";
                body.MimeType = "application/zip";
                body.Parents = null;// new List<ParentReference>() { new ParentReference() { Id = _parent } };
                //body.Parents = null;

                // File's content.
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, "application/zip");
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occurred: " + e.Message);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("File does not exist: " + _uploadFile);
                return null;
            }
        }
        public void backup_data()
        {
            using (ZipFile archive = new ZipFile())
            {
                archive.AddDirectory(Constants.root_path);
                archive.Save("links_backup.zip");
            }
            //AppDomain.CurrentDomain.BaseDirectory
            uploadFile("links_backup.zip");
        }

    }
}
