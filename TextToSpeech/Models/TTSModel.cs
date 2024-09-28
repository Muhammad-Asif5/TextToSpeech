using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TextToSpeech.Models
{
    public class TTSModel
    {
        [Required(ErrorMessage = "Please enter some text.")]
        [StringLength(500, ErrorMessage = "Text cannot exceed 500 characters.")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Please select a voice.")]
        public string SelectedVoice { get; set; }

        public List<SelectListItem> Voices { get; set; } = new List<SelectListItem>
        {
           new SelectListItem { Value = "en-US-GuyNeural", Text = "Guy - Male (US)" },
            new SelectListItem { Value = "en-GB-RyanNeural", Text = "Ryan - Male (UK)" },
            new SelectListItem { Value = "en-US-AriaNeural", Text = "Aria - Female (US)" },
            new SelectListItem { Value = "en-GB-SoniaNeural", Text = "Sonia - Female (UK)" },
            new SelectListItem { Value = "en-AU-WilliamNeural", Text = "William - Male (Australia)" },
            new SelectListItem { Value = "en-IN-NeerjaNeural", Text = "Neerja - Female (India)" },
            new SelectListItem { Value = "en-CA-ClaraNeural", Text = "Clara - Female (Canada)" },
            new SelectListItem { Value = "en-NZ-MitchellNeural", Text = "Mitchell - Male (New Zealand)" },

              // New voices, including Eric
            new SelectListItem { Value = "en-US-EricNeural", Text = "Eric - Male (US)" },
            new SelectListItem { Value = "en-IE-ConnorNeural", Text = "Connor - Male (Ireland)" },
            new SelectListItem { Value = "en-SG-LunaNeural", Text = "Luna - Female (Singapore)" },
            new SelectListItem { Value = "en-ZA-LeahNeural", Text = "Leah - Female (South Africa)" },
            new SelectListItem { Value = "fr-CA-AntoineNeural", Text = "Antoine - Male (French Canada)" },
            new SelectListItem { Value = "de-DE-ConradNeural", Text = "Conrad - Male (Germany)" },
            new SelectListItem { Value = "es-ES-AlvaroNeural", Text = "Alvaro - Male (Spain)" },
            new SelectListItem { Value = "es-MX-DaliaNeural", Text = "Dalia - Female (Mexico)" },
            new SelectListItem { Value = "it-IT-ElsaNeural", Text = "Elsa - Female (Italy)" },
            new SelectListItem { Value = "pt-BR-FranciscaNeural", Text = "Francisca - Female (Brazil)" },
            new SelectListItem { Value = "ja-JP-NanamiNeural", Text = "Nanami - Female (Japan)" }

        };
    }

}
