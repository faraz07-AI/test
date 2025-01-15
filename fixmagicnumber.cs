using System;
using NUnit.Framework;
using ExampleVRNamespace;

namespace VRLazyTestExample
{
    public class VRLazyTests
    {
        private ExampleVRUnitTest _vrTestObject;

        [SetUp]
        public void SetUp()
        {
            // Initialize the production object
            _vrTestObject = new ExampleVRUnitTest();
        }  

        [TestMethod]
        public void SQLite_BaseStationDatabase_UpdateSession_Works_For_Different_Cultures()
        {
            BaseStationDatabase_UpdateSession_Works_For_Dvifferent_Cultures(timeGetsRounded: true);
        }
         
        
        [Test]
        public void TransformInactiveComponent()
        {
            UnityEventListenerMock transformedListenerMock = new UnityEventListenerMock();
            UnityEventListenerMock failedListenerMock = new UnityEventListenerMock();
            subject.Transformed.AddListener(transformedListenerMock.Listen);
            subject.Failed.AddListener(failedListenerMock.Listen);
            FloatObservableList collection = containingObject.AddComponent<FloatObservableList>();
            subject.Collection = collection;
            subject.Collection.Add(1f);
            subject.Collection.Add(2f);
            subject.Collection.Add(3f);
            subject.Collection.Add(4f);

            subject.enabled = false;

            Assert.AreEqual(0f, subject.Result);
            Assert.IsFalse(transformedListenerMock.Received);
            Assert.IsFalse(failedListenerMock.Received);

            float result = subject.Transform();

            Assert.AreEqual(0f, result);
            Assert.AreEqual(0f, subject.Result);
            Assert.IsFalse(transformedListenerMock.Received);
            Assert.IsFalse(failedListenerMock.Received);
        }

        [TestMethod]
        public void AdsbTranslator_Translate_Decodes_Target_State_Version_2_Autopilot_State_Flags_Correctly()
        {
            for(var valid = 0;valid < 2;++valid) {
                for(var autopilot = 0;autopilot < 2;++autopilot) {
                    for(var vnav = 0;vnav < 2;++vnav) {
                        for(var altitudeHold = 0;altitudeHold < 2;++altitudeHold) {
                            for(var adsr = 0;adsr < 2;++adsr) {
                                for(var approach = 0;approach < 2;++approach) {
                                    for(var tcas = 0;tcas < 2;++tcas) {
                                        for(var lnav = 0;lnav < 2;++lnav) {
                                            var bits = String.Format("11101 01 0 00000000 00000000 00000000 00000000 000000 {0} {1} {2} {3} {4} {5} {6} {7} 00",
                                                valid,
                                                autopilot,
                                                vnav,
                                                altitudeHold,
                                                adsr,
                                                approach,
                                                tcas,
                                                lnav);
                                            var version2 = Translate(bits).TargetStateAndStatus.Version2;

                                            Assert.AreEqual(adsr == 1, version2.IsRebroadcast);
                                            Assert.AreEqual(tcas == 1, version2.IsTcasOperational);

                                            if(valid == 0) {
                                                Assert.IsNull(version2.IsAutopilotEngaged);
                                                Assert.IsNull(version2.IsVnavEngaged);
                                                Assert.IsNull(version2.IsAltitudeHoldActive);
                                                Assert.IsNull(version2.IsApproachModeActive);
                                                Assert.IsNull(version2.IsLnavEngaged);
                                            } else {
                                                Assert.AreEqual(autopilot == 1, version2.IsAutopilotEngaged);
                                                Assert.AreEqual(vnav == 1, version2.IsVnavEngaged);
                                                Assert.AreEqual(altitudeHold == 1, version2.IsAltitudeHoldActive);
                                                Assert.AreEqual(approach == 1, version2.IsApproachModeActive);
                                                Assert.AreEqual(lnav == 1, version2.IsLnavEngaged);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
         
        #region ListModels
        [UnityTest, Order(1)]
        public IEnumerator TestListModels()
        {
            Log.Debug("SpeechToTextServiceV1IntegrationTests", "Attempting to ListModels...");
            SpeechModels listModelsResponse = null;
            service.ListModels(
                callback: (DetailedResponse<SpeechModels> response, IBMError error) =>
                {
                    Log.Debug("SpeechToTextServiceV1IntegrationTests", "ListModels result: {0}", response.Response);
                    listModelsResponse = response.Result;
                    Assert.IsNotNull(listModelsResponse);
                    Assert.IsNotNull(listModelsResponse.Models);
                    Assert.IsTrue(listModelsResponse.Models.Count > 0);
                    Assert.IsNull(error);
                }
            );

            while (listModelsResponse == null)
                yield return null;
        }
        #endregion
        
        [UnityTest, Order(1)]
        public IEnumerator TestListModels()
        {
            Log.Debug("SpeechToTextServiceV1IntegrationTests", "Attempting to ListModels...");
            SpeechModels listModelsResponse = null;
            service.ListModels(
                callback: (DetailedResponse<SpeechModels> response, IBMError error) =>
                {
                    Log.Debug("SpeechToTextServiceV1IntegrationTests", "ListModels result: {0}", response.Response);
                    listModelsResponse = response.Result;
                    Assert.IsNotNull(listModelsResponse);
                    Assert.IsNotNull(listModelsResponse.Models);
                    Assert.IsTrue(listModelsResponse.Models.Count > 0);
                    Assert.IsNull(error);
                }
            );

            while (listModelsResponse == null)
                yield return null;
        }
        #endregion

        [TestMethod]
		public void CanParseStream()
		{
			var result = parser.Parse("D:/Filmy360/EHF2016.mp4");
			Assert.IsTrue(result.videoStreams.Count > 0, "no video streams");
			Assert.IsFalse(result.videoStreams.Exists(vs => vs.url == null), "some url contains nulls");
			Assert.AreEqual(MediaDecoder.ProjectionMode.Sphere, result.projection);
			Assert.AreEqual(MediaDecoder.VideoMode.Mono, result.stereoscopy);
		}
        
        [UnityTest, Order(11)]
        public IEnumerator TestListWords()
        {
            Log.Debug("TextToSpeechServiceV1IntegrationTests", "Attempting to ListWords...");
            Words listWordsResponse = null;
            service.ListWords(
                callback: (DetailedResponse<Words> response, IBMError error) =>
                {
                    Log.Debug("TextToSpeechServiceV1IntegrationTests", "ListWords result: {0}", response.Response);
                    listWordsResponse = response.Result;
                    Assert.IsNotNull(listWordsResponse);
                    Assert.IsNotNull(listWordsResponse._Words);
                    Assert.IsTrue(listWordsResponse._Words.Count > 0);
                    Assert.IsNull(error);
                },
                customizationId: customizationId
            );

            while (listWordsResponse == null)
                yield return null;
        }
      
        [Test]
        public void ActivatedEmitted()
        {
            UnityEventListenerMock activatedListenerMock = new UnityEventListenerMock();
            UnityEventListenerMock deactivatedListenerMock = new UnityEventListenerMock();
            UnityEventListenerMock changedListenerMock = new UnityEventListenerMock();

            subject.Activated.AddListener(activatedListenerMock.Listen);
            subject.Deactivated.AddListener(deactivatedListenerMock.Listen);
            subject.ValueChanged.AddListener(changedListenerMock.Listen);

            Assert.AreEqual(0f, subject.Value);
            Assert.IsFalse(activatedListenerMock.Received);
            Assert.IsFalse(deactivatedListenerMock.Received);
            Assert.IsFalse(changedListenerMock.Received);

            subject.Receive(1f);

            Assert.AreEqual(1f, subject.Value);
            Assert.IsTrue(activatedListenerMock.Received);
            Assert.IsFalse(deactivatedListenerMock.Received);
            Assert.IsTrue(changedListenerMock.Received);
        }

    }
}
