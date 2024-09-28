using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using TextToSpeech.Models;

namespace TextToSpeech.Controllers
{
    public class TextToSpeechController : Controller
    {
        private readonly string subscriptionKey;
        private readonly string region;
        public TextToSpeechController(IConfiguration configuration)
        {
            subscriptionKey = configuration["AzureSpeech:SubscriptionKey"];
            region = configuration["AzureSpeech:Region"];
        }


        public IActionResult Index()
        {
            var model = new TTSModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateSpeech(TTSModel model)
        {
            if (string.IsNullOrEmpty(model.Text) || string.IsNullOrEmpty(model.SelectedVoice))
            {
                ModelState.AddModelError("", "Text and voice selection are required.");
                return View("Index", model);
            }
            var config = SpeechConfig.FromSubscription(subscriptionKey, region);
            config.SpeechSynthesisVoiceName = model.SelectedVoice;

            using (var synthesizer = new SpeechSynthesizer(config, null))
            {
                var result = await synthesizer.SpeakTextAsync(model.Text);

                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    var audioStream = new MemoryStream(result.AudioData);
                    audioStream.Position = 0;

                    return File(audioStream, "audio/mpeg");

                    //var fileName = $"{model.SelectedVoice}_speech.mp3";
                    //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "audio", fileName);
                    //Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    //await System.IO.File.WriteAllBytesAsync(filePath, result.AudioData);
                    //// Return the file for download
                    //return File(System.IO.File.OpenRead(filePath), "audio/mpeg", fileName);
                }
                else
                {
                    ModelState.AddModelError("", "Error generating speech.");
                    return View("Index", model);
                }
            }
        }
    }
}
