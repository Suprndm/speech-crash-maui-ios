using Microsoft.CognitiveServices.Speech;

namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await GenerateVoice("小心踩到客厅里的玻璃碎片，但是房东已经打扫过了");
    }

    public async Task GenerateVoice(string text)
    {
        //
        // For more samples please visit https://github.com/Azure-Samples/cognitive-services-speech-sdk 
        // 

        // Creates an instance of a speech config with specified subscription key and service region.
        string subscriptionKey = "****************";
        string subscriptionRegion = "*************";

        var config = SpeechConfig.FromSubscription(subscriptionKey, subscriptionRegion);
        // Note: the voice setting will not overwrite the voice element in input SSML.
        config.SpeechSynthesisVoiceName = "zh-CN-YunxiNeural";

        // use the default speaker as audio output.
        using (var synthesizer = new SpeechSynthesizer(config))
        {
            using (var result = await synthesizer.SpeakTextAsync(text))
            {
                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                }
                else
                {
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                }
            }
        }
    }
}

