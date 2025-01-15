using System;
using NUnit.Framework;
using ExampleVRNamespace;

namespace VRLazyTestExample
{
   
  public class MinHeapTest {
    private class HeapElement : IMinHeapNode, IComparable<HeapElement> {
        public int heapIndex { get; set; }
        public float value;

         public HeapElement(float value) {
           this.value = value;
         }

        [UnityTest]
        public IEnumerator ShouldPauseSound()
        {
            am.Play(s.name);
            yield return new WaitForSeconds(TestConstants.WAIT_TIME);
            am.Pause(s.name);
            Assert.False(s.source.isPlaying);
        }

        
        [Test]
        [Category("Actions")]
        [Ignore("TODO")]
        public void TODO_Actions_CompositesWithMissingBindings_ThrowExceptions()
        {
           Assert.Fail();
        }

        [Test]
        [Category("Users")]
        [Ignore("TODO")]
        public void TODO_Users_CanPauseAndResumeHaptics()
        {  
           Assert.Fail();
        }
   
        [Test]
        public void GlbLengthTest()
        {
            var env = System.Environment.GetEnvironmentVariable("GLTF_SAMPLE_MODELS");
            if (string.IsNullOrEmpty(env))
            {
                return;
            }
            var root = new DirectoryInfo($"{env}/2.0");
            if (!root.Exists)
            {
                return;
            }

            var path = Path.Combine(root.ToString(), "DamagedHelmet\\glTF-Binary\\DamagedHelmet.glb");
            Assert.True(File.Exists(path));

            var bytes = File.ReadAllBytes(path);
            using (var data = new GlbBinaryParser(bytes, Path.GetFileNameWithoutExtension(path)).Parse())
            {

                // glb header + 1st chunk only
                var mod = bytes.Take(12 + 8 + data.Chunks[0].Bytes.Count).ToArray();

                Assert.Throws<GlbParseException>(() =>
                {
                // 再パース
                var data2 = new GlbBinaryParser(mod, Path.GetFileNameWithoutExtension(path)).Parse();
                });
            }
        }

        
        [Test]
        public void BuildingIntroTest()
        {
            // Given a builder with a predefined Intro step
            LinearTrainingBuilder builder = new LinearTrainingBuilder("TestTraining")
                .AddChapter(new LinearChapterBuilder("TestChapter")
                    .AddStep(DefaultSteps.Intro("TestIntroStep")));

            // When we build a training from it,
            IStep step = builder.Build().Data.FirstChapter.Data.FirstStep;

            // Then a training with an Intro step is created.
            Assert.True(step != null);
            Assert.True(step.Data.Name == "TestIntroStep");
            Assert.True(step.Data.Transitions.Data.Transitions.First().Data.Conditions.Any() == false);
        }

        
       [UnityTest]
       public IEnumerator CanvasScalerWithChildTextObjectWithTextFontDoesNotCrash()
       {
        //This adds a Canvas component as well
        m_CanvasObject = new GameObject("Canvas");
        var canvasScaler = m_CanvasObject.AddComponent<CanvasScaler>();
        m_CanvasObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

        //the crash only reproduces if the text component is a child of the game object
        //that has the CanvasScaler component and if it has an actual font and text set
        var textObject = new GameObject("Text").AddComponent<UnityEngine.UI.Text>();
        textObject.font = Font.CreateDynamicFontFromOSFont("Arial", 14);
        textObject.text = "New Text";
        textObject.transform.SetParent(m_CanvasObject.transform);
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(1080, 1020);

        //The crash happens when setting the referenceResolution to a small value
        canvasScaler.referenceResolution = new Vector2(9, 9);

        //We need to wait a few milliseconds for the crash to happen, otherwise Debug.Log will
        //get executed and the test will pass
        yield return new WaitForSeconds(0.1f);

        Assert.That(true);
       }
         
        [Test]
        [Category("Layouts")]
        public void Layouts_BuildingLayoutInCode_WithEmptyUsageString_Throws()
        {
             var builder = new InputControlLayout.Builder().WithName("TestLayout");

            Assert.That(() => builder.AddControl("TestControl").WithUsages(""),
            Throws.ArgumentException.With.Message.Contains("TestControl")
                .And.With.Message.Contains("TestLayout"));
        }
        
        
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidCapacity([Values(int.MinValue, -1, 0)] int minCapacity) {
          new RingBuffer<int>(minCapacity);
        }
      
        [Test]
        [Category("Actions")]
        public void Actions_CannotAddSameMapToTwoDifferentAssets()
        {
            var asset1 = ScriptableObject.CreateInstance<InputActionAsset>();
            var asset2 = ScriptableObject.CreateInstance<InputActionAsset>();
            var map = new InputActionMap("map");

            asset1.AddActionMap(map);

            Assert.That(() => asset2.AddActionMap(map), Throws.InvalidOperationException);
        }
     
	[UnityTest]
	public IEnumerator CanSpawnCherry()
	{
		// Populate more food so the cherry can spawn
		for (int i = 0; i <= 41; i++)
		{
			MonoBehaviour.Instantiate(food);
		}
		goManager.CountFood();
		goManager.SpawnCherry();
		yield return new WaitForSeconds(WAIT_TIME);
		Assert.IsNotNull(GameObject.FindGameObjectWithTag("Cherry"));
	}
	    
        [UnityTest]
        public IEnumerator TestSuiteWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
        
	[UnityTest]
	public IEnumerator GhostCanBecomeEdible()
	{
	    ghost.BecomeEdible();
	    yield return new WaitForSeconds(WAIT_TIME);
	    Assert.True(ghost.IsEdible());
	}  

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

        
        [TestMethod]
        public void DirectoryCache_CacheChanged_Not_Raised_If_Folder_Does_Not_Change()
        {
            _DirectoryCache.Folder = "x";

            _DirectoryCache.CacheChanged += _CacheChangedEvent.Handler;
            _DirectoryCache.Folder = "x";

            Assert.AreEqual(0, _CacheChangedEvent.CallCount);
        }

        [UnityTest]
        public IEnumerator CoordinateSystemsTestScriptsWithEnumeratorPasses()
        {
           // Use the Assert class to test conditions.
           // yield to skip a frame
           yield return null;
        }
     
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses() {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
         }
        
        [Test]
        public void DeviceList_operator_index() {
           // !!!DeviceList_operator_index
           DeviceList allDevices = controller.Devices;
           for (int index = 0; index < allDevices.Count; index++) {
               Console.WriteLine(allDevices[index]);
          }
	}
      // !!!END

        [TestMethod]
        public void AllComponentsTest()
        {
            Console.WriteLine("All Components Test Start");
            NewTestWorld();
            Console.WriteLine("Done Clreaing last Test");
            var assem = Assembly.GetAssembly(typeof(Component));
            var types =
              from t in assem.GetTypes().AsParallel()
              where t.IsAssignableTo(typeof(Component))
              select t;
            foreach (var item in types)
            {
                TestComponent(item);
            }
            //Parallel.ForEach(types, TestWorker);
        }

        
        [Test]
        public void ConstructFromInts()
        {
            IntRange range = new IntRange(1, 2);
            Assert.AreEqual(1, range.minimum);
            Assert.AreEqual(2, range.maximum);
        }

        
        [TestMethod]
        public void SQLite_BaseStationDatabase_UpdateSession_Does_Nothing_If_File_Does_Not_Exist()
        {
            _Database.WriteSupportEnabled = true;
            RetryAction(() => File.Delete(_EmptyDatabaseFileName));

            _Database.UpdateSession(new BaseStationSession());
            Assert.AreEqual(0, _Database.GetSessions().Count);
        }


     [UnityTest]
     public IEnumerator WhenChangeSliderValuesIndependentlyMultipleTimes_ThenBothAudioSourcesVolumeLevelsMatch()
     {
            float[] expectedMusicVolumeLevels = { 0f,  0.25f, 1/3f, 0.5f, 2/3f, 0.75f, 1f };
            float[] expectedFxVolumeLevels = expectedMusicVolumeLevels.Reverse().ToArray();

            for (int i = 0; i < expectedMusicVolumeLevels.Length; i++)
            {
                var expectedMusicVolume = expectedMusicVolumeLevels[i];
                var expectedFxVolume = expectedFxVolumeLevels[i];
                
                // Set slider value
                _musicAudioSliderComponent.value = expectedMusicVolume;
                _fxAudioSliderComponent.value = expectedFxVolume;
        
                yield return null;
                
                Assert.AreEqual(expectedMusicVolume, _musicAudioSliderComponent.value, 0.0, 
                    $"After setting music slider value, unexpected slider '{MusicSliderName}' value");
                
                Assert.AreEqual(expectedMusicVolume, _musicAudioSourceComponent.volume, 0.0, 
                    $"After setting music slider value, unexpected audio source '{MusicAudioSourceName}' volume");
                
                Assert.AreEqual(expectedFxVolume, _fxAudioSliderComponent.value, 0.0, 
                    $"After setting FX slider value, unexpected slider '{FxSliderName}' value");
                
                Assert.AreEqual(expectedFxVolume, _fxAudioSourceComponent.volume, 0.0, 
                    $"After setting FX slider value, unexpected audio source '{FxAudioSourceName}' volume");
            }
       }

         
        [Test]
        public void ConstructRawImagePresenter()
        {
            var presenter = new RawImagePresenter("Image");
            Assert.AreEqual(0, presenter.Children.Count());
            Assert.AreEqual("Image", presenter.DisplayName);
        }


        
        [Test]
        public void AddMultipleControlPointsWithCommandUndo()
        {
            AddControlPointCommand command = new AddControlPointCommand(this.LineSketchObject, new Vector3(1, 2, 3));
            Invoker.ExecuteCommand(command);

            command = new AddControlPointCommand(this.LineSketchObject, new Vector3(2, 3, 4));
            Invoker.ExecuteCommand(command);

            command = new AddControlPointCommand(this.LineSketchObject, new Vector3(3, 3, 3));
            Invoker.ExecuteCommand(command);

            command = new AddControlPointCommand(this.LineSketchObject, new Vector3(4, 3, 2));
            Invoker.ExecuteCommand(command);
            Invoker.Undo();

            Assert.AreEqual(this.LineSketchObject.getNumberOfControlPoints(), 3);
            Assert.AreEqual((2 * 20 + 2) * 7, this.LineSketchObject.GetComponent<MeshFilter>().sharedMesh.vertices.Length);
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

        [TestMethod]
        public void SQLite_BaseStationDatabase_GetSessions_Returns_Empty_List_If_File_Not_Configured()
        {
            _Database.FileName = null;

            Assert.AreEqual(0, _Database.GetSessions().Count);
        }

        
        [Test]
        public void IntegerValue()
        {
            subject.Timeline = animator;
            subject.ParameterName = "IntegerTest";
            Assert.AreEqual(0, animator.GetInteger("IntegerTest"));

            subject.IntegerValue = 1;

            Assert.AreEqual(1, animator.GetInteger("IntegerTest"));
            Assert.AreEqual(1, subject.IntegerValue);
        }


        
        [TestMethod]
        public void MergedFeedListener_SetListener_BaseStationMessage_Events_On_Listeners_Passed_Through()
        {
            _MergedFeed.SetListeners(_Components);
            _MergedFeed.Port30003MessageReceived += _BaseStationMessageEventRecorder.Handler;

            var args = new BaseStationMessageEventArgs(new BaseStationMessage());
            _Listener1.Raise(r => r.Port30003MessageReceived += null, args);

            Assert.AreEqual(1, _BaseStationMessageEventRecorder.CallCount);
            Assert.AreSame(_MergedFeed, _BaseStationMessageEventRecorder.Sender);
            Assert.AreSame(args.Message, _BaseStationMessageEventRecorder.Args.Message);
        }

        

        [TestMethod]
        public void MergedFeedListener_ExceptionCaught_Raised_If_Exception_Thrown_By_BaseStation_Event_Handler()
        {
            _MergedFeed.ExceptionCaught += _ExceptionCaughtRecorder.Handler;
            _MergedFeed.Port30003MessageReceived += _BaseStationMessageEventRecorder.Handler;

            var exception = new InvalidCastException();
            _BaseStationMessageEventRecorder.EventRaised += (sender, args) => { throw exception; };

            _MergedFeed.SetListeners(_Components);
            _Listener1.Raise(r => r.Port30003MessageReceived += null, new BaseStationMessageEventArgs(new BaseStationMessage()));

            Assert.AreEqual(1, _ExceptionCaughtRecorder.CallCount);
            Assert.AreSame(_MergedFeed, _ExceptionCaughtRecorder.Sender);
            Assert.AreSame(exception, _ExceptionCaughtRecorder.Args.Value);
        }
        #endregion


        
        [UnityTest]
        public IEnumerator SetAtOrAddIfEmptyCollection()
        {
            UnityEventListenerMock addedMock = new UnityEventListenerMock();
            UnityEventListenerMock removedMock = new UnityEventListenerMock();
            subject.Added.AddListener(addedMock.Listen);
            subject.Removed.AddListener(removedMock.Listen);

            GameObject elementOne = new GameObject("One");

            yield return null;

            Assert.AreEqual(0, subject.NonSubscribableElements.Count);

            subject.SetAtOrAddIfEmpty(elementOne, 1);

            Assert.AreEqual(elementOne, subject.NonSubscribableElements[0]);

            Assert.IsTrue(addedMock.Received);
            Assert.IsFalse(removedMock.Received);

            Object.DestroyImmediate(elementOne);
        }


        [TestMethod]
        public void RawMessageTranslator_Translate_Copies_SignalLevel_From_ModeSMessage_To_BaseStationMessage()
        {
            foreach(var modeSMessage in CreateModeSMessagesWithPIField().Concat(CreateModeSMessagesWithNoPIField())) {
                modeSMessage.Icao24 = 112233;

                modeSMessage.SignalLevel = 99;
                var baseStationMessage = _Translator.Translate(_NowUtc, modeSMessage, null);
                Assert.AreEqual(99, baseStationMessage.SignalLevel);

                modeSMessage.SignalLevel = null;
                baseStationMessage = _Translator.Translate(_NowUtc, modeSMessage, null);
                Assert.AreEqual(null, baseStationMessage.SignalLevel);
            }
        }

        
        [Test]
        public void TransformInactiveComponent()
        {
            Vector2EqualityComparer comparer = new Vector2EqualityComparer(0.1f);
            UnityEventListenerMock transformedListenerMock = new UnityEventListenerMock();
            subject.Transformed.AddListener(transformedListenerMock.Listen);
            subject.enabled = false;

            Assert.That(subject.Result, Is.EqualTo(Vector2.zero).Using(comparer));
            Assert.IsFalse(transformedListenerMock.Received);

            float[] input = new float[] { 2f, 3f };
            Vector2 result = subject.Transform(input);

            Assert.That(result, Is.EqualTo(Vector2.zero).Using(comparer));
            Assert.That(subject.Result, Is.EqualTo(Vector2.zero).Using(comparer));
            Assert.IsFalse(transformedListenerMock.Received);
        }

        
        [TestMethod]
        public void AccessConfiguration_SetRestrictedPath_Records_Access_To_Path()
        {
            var access = new Access() { DefaultAccess = DefaultAccess.Deny };
            _Configuration.SetRestrictedPath("/MyPlugin/", access);

            var map = _Configuration.GetRestrictedPathsMap();

            Assert.AreEqual(1, map.Count);
            Assert.AreEqual("/MyPlugin/", map.Single().Key);
            Assert.AreEqual(access, map.Single().Value);
        }

        
        [Test]
        public void ComputeMipmapDimensions_F_CorrectResults() {
            TextureUtils.ComputeMipmapDimensions(256, 64, 9, out int mipWidth, out int mipHeight);
            Assert.AreEqual(0, mipWidth);
            Assert.AreEqual(0, mipHeight);
        }
   
        [TestMethod]
        public void SQLite_BaseStationDatabase_InsertSystemEvents_Works_For_Different_Cultures()
        {
            BaseStationDatabase_InsertSystemEvents_Works_For_Different_Cultures();
        }
        
        [Test]
        public void TestBasics() {
            var thenull = CreateObject();
            base.TestBasics(thenull, FbxNodeAttribute.EType.eNull);

            Assert.AreEqual(100.0, thenull.GetSizeDefaultValue());
            TestGetter(FbxNull.sSize);
            TestGetter(FbxNull.sLook);
            Assert.AreEqual(thenull.Size, thenull.FindProperty(FbxNull.sSize));
            Assert.AreEqual(thenull.Look, thenull.FindProperty(FbxNull.sLook));

            thenull.Size.Set(7);
            thenull.Reset();
            Assert.AreEqual(FbxNull.sDefaultSize, thenull.Size.Get());
            Assert.AreEqual(FbxNull.sDefaultLook, thenull.Look.Get());
        }

         
		[Test, Order(1)]
		public void FixturesLoaded()
		{
			Assert.AreEqual(14, _trace.Count);
			Assert.AreEqual(12, _probes.Count);
		}

        
        [Test]
        public void DecreaseCountInactiveComponent()
        {
            UnityEventListenerMock addedMock = new UnityEventListenerMock();
            UnityEventListenerMock removedMock = new UnityEventListenerMock();
            subject.Added.AddListener(addedMock.Listen);
            subject.Removed.AddListener(removedMock.Listen);
            GameObject elementOne = new GameObject("GameObjectObservableCounterTest");

            subject.IncreaseCount(elementOne);
            subject.IncreaseCount(elementOne);

            addedMock.Reset();
            removedMock.Reset();

            Assert.IsFalse(addedMock.Received);
            Assert.IsFalse(removedMock.Received);
            Assert.AreEqual(2, subject.GetCount(elementOne));

            subject.enabled = false;

            subject.DecreaseCount(elementOne);

            Assert.IsFalse(addedMock.Received);
            Assert.IsFalse(removedMock.Received);
            Assert.AreEqual(2, subject.GetCount(elementOne));

            addedMock.Reset();
            removedMock.Reset();

            subject.DecreaseCount(elementOne);

            Assert.IsFalse(addedMock.Received);
            Assert.IsFalse(removedMock.Received);
            Assert.AreEqual(2, subject.GetCount(elementOne));

            Assert.IsTrue(subject.ElementsCounter.ContainsKey(elementOne));

            Object.DestroyImmediate(elementOne);
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

         #region Translate - Latitude and Longitude
        [TestMethod]
        [DataSource("Data Source='RawDecodingTests.xls';Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Extended Properties='Excel 8.0'",
                    "RawTranslatePosition$")]
        public void RawMessageTranslator_Translate_Extracts_Position_From_ADSB_Messages_Correctly()
        {
            var worksheet = new ExcelWorksheetData(TestContext);

            _Translator.ReceiverLocation = ParseGlobalPosition(worksheet.String("ReceiverPosn"));
            _Translator.ReceiverRangeKilometres = worksheet.Int("Range");
            _Translator.GlobalDecodeAirborneThresholdMilliseconds = worksheet.Int("GATS");
            _Translator.GlobalDecodeFastSurfaceThresholdMilliseconds = worksheet.Int("GFSTS");
            _Translator.GlobalDecodeSlowSurfaceThresholdMilliseconds = worksheet.Int("GSSTS");
            _Translator.LocalDecodeMaxSpeedAirborne = worksheet.Double("LAMS");
            _Translator.LocalDecodeMaxSpeedTransition = worksheet.Double("LTMS");
            _Translator.LocalDecodeMaxSpeedSurface = worksheet.Double("LSMS");
            _Translator.SuppressReceiverRangeCheck = worksheet.Bool("SRRC");
            _Translator.UseLocalDecodeForInitialPosition = worksheet.Bool("ULD");

            DateTime now = DateTime.UtcNow;
            for(var i = 1;i <= 4;++i) {
                var millisecondsColumn = String.Format("MSec{0}", i);
                var cprColumn = String.Format("CPR{0}", i);
                var speedColumn = String.Format("Spd{0}", i);
                var positionColumn = String.Format("Posn{0}", i);

                if(worksheet.String(cprColumn) == null) continue;
                var cpr = ParseCpr(worksheet.String(cprColumn));
                var speed = worksheet.NDouble(speedColumn);
                var expectedPosition = ParseGlobalPosition(worksheet.String(positionColumn));

                if(i != 1 && worksheet.String(millisecondsColumn) != null) {
                    now = now.AddMilliseconds(worksheet.Int(millisecondsColumn));
                }

                var modeSMessage = new ModeSMessage() { DownlinkFormat = DownlinkFormat.ExtendedSquitter, Icao24 = 0x112233, ParityInterrogatorIdentifier = 0 };
                var adsbMessage = new AdsbMessage(modeSMessage);
                switch(cpr.NumberOfBits) {
                    case 17:
                        adsbMessage.MessageFormat = MessageFormat.AirbornePosition;
                        adsbMessage.AirbornePosition = new AirbornePositionMessage() { CompactPosition = cpr };
                        break;
                    case 19:
                        adsbMessage.MessageFormat = MessageFormat.SurfacePosition;
                        adsbMessage.SurfacePosition = new SurfacePositionMessage() { CompactPosition = cpr, GroundSpeed = speed, };
                        break;
                }

                var baseStationMessage = _Translator.Translate(now, modeSMessage, adsbMessage);

                var failMessage = String.Format("Failed on message {0}", i);
                if(expectedPosition == null) {
                    if(baseStationMessage != null) {
                        if(baseStationMessage.Latitude != null || baseStationMessage.Longitude != null) {
                            Assert.Fail(String.Format("Position decoded to {0}/{1} erroneously. {2}", baseStationMessage.Latitude, baseStationMessage.Longitude, failMessage));
                        }
                    }
                } else {
                    Assert.IsNotNull(baseStationMessage.Latitude, failMessage);
                    Assert.IsNotNull(baseStationMessage.Longitude, failMessage);
                    Assert.AreEqual(expectedPosition.Latitude, baseStationMessage.Latitude.Value, 0.0001, failMessage);
                    Assert.AreEqual(expectedPosition.Longitude, baseStationMessage.Longitude.Value, 0.0001, failMessage);
                }
            }

            Assert.AreEqual(worksheet.Int("ResetCount"), _PositionResetEvent.CallCount);
            Assert.AreEqual(worksheet.Int("ResetCount") > 0 ? 1L : 0L, _Statistics.Object.AdsbPositionsReset);
            Assert.AreEqual(worksheet.Long("BadRange"), _Statistics.Object.AdsbPositionsOutsideRange);
            Assert.AreEqual(worksheet.Long("BadSpeed"), _Statistics.Object.AdsbPositionsExceededSpeedCheck);
        }

        [TestMethod]
		public void CanParseStream()
		{
			var result = parser.Parse("D:/Filmy360/EHF2016.mp4");
			Assert.IsTrue(result.videoStreams.Count > 0, "no video streams");
			Assert.IsFalse(result.videoStreams.Exists(vs => vs.url == null), "some url contains nulls");
			Assert.AreEqual(MediaDecoder.ProjectionMode.Sphere, result.projection);
			Assert.AreEqual(MediaDecoder.VideoMode.Mono, result.stereoscopy);
		}
    
        [TestMethod("写真のリストからそれに含まれるユーザーリストを作成する(ユーザーに重複なし)")]
        public void CreateUserListFromPhotoList()
        {
            var photoList = new ReactiveCollection<Photo>();
            var usersModel = new Users(photoList);

            var privateObject = new PrivateObject(usersModel);
            var userlist = privateObject.GetProperty("_userList") as ReadOnlyReactiveCollection<string>;
            Assert.AreEqual(0, userlist.Count);

            foreach (var photo in _photoListWithOneUser)
            {
                photoList.Add(photo);
            }

            Assert.AreEqual(5, userlist.Count);
        }

        [TestMethod]
        public void ConnectionLogger_Start_Ignores_Null_IPAddresses()
        {
            var now = SetUtcNow(DateTime.Now);
            _ConnectionLogger.Start();

            RaiseResponseEvent(null, null, 7L, ContentClassification.Audio, now);

            _LogDatabase.Verify(d => d.EstablishSession(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
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
        public void TestEditorOnly()
        {
#if VQT_HAS_VRCSDK
            var scene = OpenTestScene();
            var root = scene.GetRootGameObjects().First((obj) => obj.name == "ChildOfEditorOnly");
            var pbs = root.GetComponentsInChildren<VRCPhysBone>(true).Select(c => new VRCSDKUtility.Reflection.PhysBone(c)).ToArray();
            var colliders = root.GetComponentsInChildren<VRCPhysBoneCollider>(true).Select(c => new VRCSDKUtility.Reflection.PhysBoneCollider(c)).ToArray();
            var contacts = root.GetComponentsInChildren<ContactBase>(true).Select(c => new VRCSDKUtility.Reflection.ContactBase(c)).ToArray();
            var perfs = AvatarDynamics.CalculatePerformanceStats(root, pbs, colliders, contacts);

            var sdkStats = new AvatarPerformanceStats(true);
            AvatarPerformance.CalculatePerformanceStats(root.name, root, sdkStats, true);

            Assert.AreEqual(0, perfs.PhysBonesCount, "PhysBones count is wrong.");
            Assert.AreEqual(0, perfs.PhysBonesTransformCount, "PhysBones transform count is wrong.");
            Assert.AreEqual(0, perfs.PhysBonesColliderCount, "PhysBoneColliders count is wrong.");
            Assert.AreEqual(0, perfs.PhysBonesCollisionCheckCount, "PhysBone collision check count is wrong.");
            Assert.AreEqual(0, perfs.ContactsCount, "Contacts count is wrong.");
#else
            Assert.Ignore("VRCSDK is not installed.");
#endif
        }


        
        [Test]
        public void RemoveLast()
        {
            UnityEventListenerMock populatedMock = new UnityEventListenerMock();
            UnityEventListenerMock addedMock = new UnityEventListenerMock();
            UnityEventListenerMock removedMock = new UnityEventListenerMock();
            UnityEventListenerMock emptiedMock = new UnityEventListenerMock();
            subject.Populated.AddListener(populatedMock.Listen);
            subject.Added.AddListener(addedMock.Listen);
            subject.Removed.AddListener(removedMock.Listen);
            subject.Emptied.AddListener(emptiedMock.Listen);

            GameObject elementOne = new GameObject("GameObjectObservableListTest");
            GameObject elementTwo = new GameObject("GameObjectObservableListTest");

            subject.RemoveLastOccurrence(elementOne);

            Assert.IsFalse(populatedMock.Received);
            Assert.IsFalse(addedMock.Received);
            Assert.IsFalse(removedMock.Received);
            Assert.IsFalse(emptiedMock.Received);

            subject.Add(elementOne);
            subject.Add(elementTwo);
            subject.Add(elementOne);

            populatedMock.Reset();
            addedMock.Reset();
            removedMock.Reset();
            emptiedMock.Reset();

            Assert.AreEqual(3, subject.NonSubscribableElements.Count);

            subject.RemoveLastOccurrence(elementOne);

            Assert.IsFalse(populatedMock.Received);
            Assert.IsFalse(addedMock.Received);
            Assert.IsTrue(removedMock.Received);
            Assert.IsFalse(emptiedMock.Received);

            Assert.AreEqual(2, subject.NonSubscribableElements.Count);
            Assert.AreEqual(elementOne, subject.NonSubscribableElements[0]);
            Assert.AreEqual(elementTwo, subject.NonSubscribableElements[1]);

            populatedMock.Reset();
            addedMock.Reset();
            removedMock.Reset();
            emptiedMock.Reset();

            subject.RemoveLastOccurrence(elementOne);

            Assert.IsFalse(populatedMock.Received);
            Assert.IsFalse(addedMock.Received);
            Assert.IsTrue(removedMock.Received);
            Assert.IsFalse(emptiedMock.Received);

            Assert.AreEqual(1, subject.NonSubscribableElements.Count);
            Assert.AreEqual(elementTwo, subject.NonSubscribableElements[0]);

            populatedMock.Reset();
            addedMock.Reset();
            removedMock.Reset();
            emptiedMock.Reset();

            subject.RemoveLastOccurrence(elementTwo);

            Assert.IsFalse(populatedMock.Received);
            Assert.IsFalse(addedMock.Received);
            Assert.IsTrue(removedMock.Received);
            Assert.IsTrue(emptiedMock.Received);

            Assert.AreEqual(0, subject.NonSubscribableElements.Count);

            populatedMock.Reset();
            addedMock.Reset();
            removedMock.Reset();
            emptiedMock.Reset();

            Object.DestroyImmediate(elementOne);
            Object.DestroyImmediate(elementTwo);
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
