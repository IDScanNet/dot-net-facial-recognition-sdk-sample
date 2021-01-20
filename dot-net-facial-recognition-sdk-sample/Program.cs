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
            var sdkDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "IDScan.net", "IDScanNet.Faces.SDK.Data");

            // path to license file
            var licenseFilePath = Path.Combine("idscannet.facesdk.license");

            var settings = new Settings
            {
                SdkDataDirectoryPath = sdkDirectoryPath,
                // this is a temporary dummy license
                License = File.ReadAllBytes(licenseFilePath)
            };

            // create and initialize face service
            var service = new FaceService(settings);

            var image1 = File.ReadAllBytes("image1.jpg");
            var image2 = File.ReadAllBytes("image2.jpg");
            var image3 = File.ReadAllBytes("image3.jpg");
            var image4 = File.ReadAllBytes("image4.jpg");
            var image5 = File.ReadAllBytes("image5.jpg");
            var image6 = File.ReadAllBytes("image6.jpg");
            var image7 = File.ReadAllBytes("image7.jpg");
            var image8 = File.ReadAllBytes("image8.jpg");
            var image9 = File.ReadAllBytes("image9.jpg");

            // detect face from given image1
            var faceSample1 = await service.DetectSingleAsync(image1);
            var faceSample2 = await service.DetectSingleAsync(image2);
            var faceSample3 = await service.DetectSingleAsync(image3);
            var faceSample4 = await service.DetectSingleAsync(image4);
            var faceSample5 = await service.DetectSingleAsync(image5);
            var faceSample6 = await service.DetectSingleAsync(image6);
            var faceSample7 = await service.DetectSingleAsync(image7);
            var faceSample8 = await service.DetectSingleAsync(image8);
            var faceSample9 = await service.DetectSingleAsync(image9);

            // compute face templates
            var template1 = await service.ComputeTemplateAsync(faceSample1);
            var template2 = await service.ComputeTemplateAsync(faceSample2);
            var template3 = await service.ComputeTemplateAsync(faceSample3);
            var template4 = await service.ComputeTemplateAsync(faceSample4);
            var template5 = await service.ComputeTemplateAsync(faceSample5);
            var template6 = await service.ComputeTemplateAsync(faceSample6);
            var template7 = await service.ComputeTemplateAsync(faceSample7);
            var template8 = await service.ComputeTemplateAsync(faceSample8);
            var template9 = await service.ComputeTemplateAsync(faceSample9);


            // compare two templates that are the same image
            var matchResult = await service.MatchAsync(template1, template2);
            Console.WriteLine($"First Black Man and Himself match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template1, template3);
            Console.WriteLine($"First Black Man and Middle Eastern Man match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template1, template4);
            Console.WriteLine($"First Black Man and Latina Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template1, template5);
            Console.WriteLine($"First Black Man and Asian Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template1, template6);
            Console.WriteLine($"First Black Man and Black Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template1, template7);
            Console.WriteLine($"First Black Man and Second Black Man match result: {matchResult.Score * 100f} %");

            // template 3
            matchResult = await service.MatchAsync(template3, template4);
            Console.WriteLine($"Middle Eastern Man and Latina Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template3, template5);
            Console.WriteLine($"Middle Eastern Man and Asian Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template3, template6);
            Console.WriteLine($"Middle Eastern Man and Black Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template3, template7);
            Console.WriteLine($"Middle Eastern Man and Black Man match result: {matchResult.Score * 100f} %");

            // template 4
            matchResult = await service.MatchAsync(template4, template5);
            Console.WriteLine($"Latina woman and Asian Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template4, template6);
            Console.WriteLine($"Latina Woman and Black Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template4, template7);
            Console.WriteLine($"Latina Woman and Black Man match result: {matchResult.Score * 100f} %");

            // template 5
            matchResult = await service.MatchAsync(template5, template6);
            Console.WriteLine($"Asian Woman and Black Woman match result: {matchResult.Score * 100f} %");

            matchResult = await service.MatchAsync(template5, template7);
            Console.WriteLine($"Asian Woman and Black Man match result: {matchResult.Score * 100f} %");

            // template 6
            matchResult = await service.MatchAsync(template6, template7);
            Console.WriteLine($"Black Woman and Black Man match result: {matchResult.Score * 100f} %");


            matchResult = await service.MatchAsync(template8, template9);
            Console.WriteLine($"Two different pics of the same person match result: {matchResult.Score * 100f} %");

            service.Dispose();
        }
    }
}
