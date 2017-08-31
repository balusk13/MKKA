using Android.Speech.Tts;
using MKKA;
using MKKAHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace MKKAHelper
{
        public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
        {
            TextToSpeech speaker;
            string toSpeak;

            public TextToSpeechImplementation() { }

            public void Speak(string text)
            {
                var ctx = Forms.Context; // useful for many Android SDK features
                toSpeak = text;
                if (speaker == null)
                {
                    speaker = new TextToSpeech(ctx, this);
                }
                else
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, "");
                }
            }

            #region IOnInitListener implementation
            public void OnInit(OperationResult status)
            {
                if (status.Equals(OperationResult.Success))
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, "");
                }
            }
            #endregion
        }
    }
