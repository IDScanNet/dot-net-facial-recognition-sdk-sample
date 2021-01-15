using IDScanNet.Faces.SDK;
using System;
using System.IO;
using System.Threading.Tasks;

namespace dot_net_facial_recognition_sdk_sample
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // path to directory containing SDK data files
            var dataDirectoryPath = Path.Combine(@"C:\ProgramData", "IDScan.net", "IDScanNet.Faces.SDK.Data");

            // path to license file
            var licenseFilePath = Path.Combine("idscannet.facesdk.license");

            var settings = new Settings
            {
                SdkDataDirectoryPath = dataDirectoryPath,
                License = new byte[] { 1 }
            };

            // create and initialize face service
            var service = new FaceService(settings);

            var image1 = File.ReadAllBytes("image1.jpg");
            var image2 = File.ReadAllBytes("image2.jpg");
            var image3 = File.ReadAllBytes("image3.jpg");

            // detect face from given image1
            var faceSample1 = await service.DetectSingleAsync(image1);

            // detect face from given image2
            var faceSample2 = await service.DetectSingleAsync(image2);

            var faceSample3 = await service.DetectSingleAsync(image3);

            // compute face templates
            var template1 = await service.ComputeTemplateAsync(faceSample1);
            var template2 = await service.ComputeTemplateAsync(faceSample2);
            var template3 = await service.ComputeTemplateAsync(faceSample3);

            // compare two templates
            var matchResult = await service.MatchAsync(template1, template2);

            Console.WriteLine($"First match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template1, template3);

            Console.WriteLine($"Second match result: {matchResult.Score * 100f} %");

            service.Dispose();
        }
    }
}
