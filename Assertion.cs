using BuildSoft.VRChat.Osc.Test;
using NUnit.Framework;

namespace BuildSoft.VRChat.Osc.Avatar.Test;

[TestOf(typeof(OscAvatar))]
public class ExampleVRUnitTest
{

    [Test]
    public void ReportRows_DateReport_Returns_Aircraft_From_FetchRows(){
        Do_ReportRows_Report_Returns_Aircraft_From_FetchRows("date", ReportJsonClass.Flight);
    }
     
       private void Do_ReportRows_Report_Returns_Aircraft_From_FetchRows(string report, ReportJsonClass reportClass)
     {
        string baseUri = "http://sonarqube.test.de/";
        string username = "";
        string password = "password";

        SqAuthValidationUriBuilder uri = new SqAuthValidationUriBuilder(baseUri, username, password);

        string expectedBaseUri = "http://sonarqube.test.de/api/authentication/validate";
        Assert.AreEqual(expectedBaseUri, uri.GetSqUri().ToString());
    }
     
    
     [UnityTest]
     public IEnumerator CastPointsInvalidTarget()
     {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            UnityEventListenerMock castResultsChangedMock = new UnityEventListenerMock();
            subject.ResultsChanged.AddListener(castResultsChangedMock.Listen);
            subject.Origin = subject.gameObject;

            validSurface.transform.position = Vector3.forward * 5f + Vector3.down * 4f;
            validSurface.AddComponent<RuleStub>();
            NegationRule negationRule = validSurface.AddComponent<NegationRule>();
            AnyComponentTypeRule anyComponentTypeRule = validSurface.AddComponent<AnyComponentTypeRule>();
            SerializableTypeComponentObservableList rules = containingObject.AddComponent<SerializableTypeComponentObservableList>();
            anyComponentTypeRule.ComponentTypes = rules;
            rules.Add(typeof(RuleStub));
            yield return null;

            negationRule.Rule = new RuleContainer
            {
                Interface = anyComponentTypeRule
            };
            subject.TargetValidity = new RuleContainer
            {
                Interface = negationRule
            };

            subject.MaximumLength = new Vector2(5f, 5f);
            subject.SegmentCount = 5;

            Physics.Simulate(Time.fixedDeltaTime);
            subject.Process();

            Vector3[] expectedPoints = new Vector3[]
            {
                Vector3.zero,
                new Vector3(0f, -0.12f, 2.89f),
                new Vector3(0f, -1.4f, 4.4f),
                new Vector3(0f, -2.8f, 4.9f),
                new Vector3(0f, validSurface.transform.position.y + (validSurface.transform.localScale.y / 2f), validSurface.transform.position.z)
            };

            for (int index = 0; index < subject.Points.Count; index++)
            {
                Assert.That(subject.Points[index], Is.EqualTo(expectedPoints[index]).Using(comparer), "Index " + index);
            }

            Assert.AreEqual(validSurface.transform, subject.TargetHit.Value.transform);
            Assert.IsFalse(subject.IsTargetHitValid);
            Assert.IsTrue(castResultsChangedMock.Received);
        }

       [Test]
        public void Test_01_TestCodeGeneratedActions()
        {
            var pressAction = new InputAction(1, "Pressed", AxisType.Digital);
            var selectAction = new InputAction(2, "Select", AxisType.Digital);

            Assert.IsTrue(selectAction != pressAction);
            Assert.IsTrue(pressAction != InputAction.None);
            Assert.IsTrue(selectAction != InputAction.None);
        }
         
        [Test]
        public void Remove()
        {
            var block = new CollisionBlock(Vector3Int.zero);
            block.AddItem(0, Vector3.left * 5);
            block.AddItem(1, Vector3.up * 15);
            
            var ray = new Ray(Vector3.zero, Vector3.up);
            Assert.AreEqual(1, block.FindItem(ray, 0.2f).Value);

            block.RemoveItem(1, Vector3.up * 15);
            Assert.IsFalse(block.FindItem(ray, 0.2f).HasValue);
        }

        [Test]
        public void ClearLeftController()
        {
            Assert.IsNull(subject.LeftController);
            subject.LeftController = containingObject;
            Assert.AreEqual(containingObject, subject.LeftController);
            subject.ClearLeftController();
            Assert.IsNull(subject.LeftController);
        }

        
        [Test]
        public void BoolValueInactiveGameObject()
        {
            subject.Timeline = animator;
            subject.ParameterName = "BoolTest";
            subject.gameObject.SetActive(false);
            Assert.IsFalse(animator.GetBool("BoolTest"));

            subject.BoolValue = true;

            Assert.IsFalse(animator.GetBool("BoolTest"));
            Assert.IsFalse(subject.BoolValue);
        }

        
        
        [UnityTest]
        public IEnumerator MissingSurfaceDueToLocatorTermination()
        {
#if UNITY_2022_2_OR_NEWER
            Physics.simulationMode = SimulationMode.FixedUpdate;
#else
            Physics.autoSimulation = true;
#endif

            GameObject terminatingSurface = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject searchOrigin = new GameObject("SearchOrigin");

            UnityEventListenerMock surfaceLocatedMock = new UnityEventListenerMock();
            subject.SurfaceLocated.AddListener(surfaceLocatedMock.Listen);

            terminatingSurface.transform.position = Vector3.forward * 5f;
            terminatingSurface.AddComponent<RuleStub>();

            AnyComponentTypeRule anyComponentTypeRule = terminatingSurface.AddComponent<AnyComponentTypeRule>();
            SerializableTypeComponentObservableList rules = containingObject.AddComponent<SerializableTypeComponentObservableList>();
            yield return null;

            anyComponentTypeRule.ComponentTypes = rules;
            rules.Add(typeof(RuleStub));

            subject.LocatorTermination = new RuleContainer
            {
                Interface = anyComponentTypeRule
            };

            subject.SearchOrigin = searchOrigin;
            subject.SearchDirection = Vector3.forward;

            yield return waitForFixedUpdate;
            subject.Locate();
            yield return waitForFixedUpdate;
            Assert.IsFalse(surfaceLocatedMock.Received);
            Assert.IsNull(subject.surfaceData.Transform);

            Object.DestroyImmediate(terminatingSurface);
            Object.DestroyImmediate(searchOrigin);
        }



        
        [TestMethod]
        public void RebroadcastServerManager_ConfigurationChanged_Disposes_Of_Old_And_Creates_New_Server_If_Format_Changes()
        {
            _Manager.Initialise();

            _RebroadcastSettings.Format = RebroadcastFormat.Port30003;
            _ConfigurationStorage.Raise(r => r.ConfigurationChanged += null, EventArgs.Empty);

            Assert.AreEqual(1, _Manager.RebroadcastServers.Count);
            Assert.AreEqual(RebroadcastFormat.Port30003, _Server.Object.Format);
            _Server.Verify(r => r.Dispose(), Times.Once());
            _Connector.Verify(r => r.Dispose(), Times.Once());
        }


         
        [Test]
        public void FindSelectableOnLeft_ReturnsNextSelectableLeftOfTarget()
        {
            Selectable selectableLeftOfTopRight = topRightSelectable.FindSelectableOnLeft();
            Selectable selectableLeftOfBottomRight = bottomRightSelectable.FindSelectableOnLeft();

            Assert.AreEqual(topLeftSelectable, selectableLeftOfTopRight, "Wrong selectable to left of Top Right Selectable");
            Assert.AreEqual(bottomLeftSelectable, selectableLeftOfBottomRight, "Wrong selectable to left of Bottom Right Selectable");
        }

        

       
        [Test]
        public void Read_OrCondition()
        {
            OrConditionDto orConditionDto = new OrConditionDto()
            {
                ConditionA = new MagnitudeConditionDto() { Magnitude = 12, BoneOrigin = 53, TargetNodeId = 15 },
                ConditionB = new ScaleConditionDto() { Scale = Vector3.one.Dto() }
            };

            poseConditionSerializerModule.Write(orConditionDto, out Bytable data);

            ByteContainer byteContainer = new ByteContainer(0, 1, data.ToBytes());

            poseConditionSerializerModule.Read(byteContainer, out bool readable, out AbstractPoseConditionDto result);
            Assert.IsTrue(readable);
            Assert.IsNotNull(result);
            Assert.AreEqual(((result as OrConditionDto).ConditionA as MagnitudeConditionDto).Magnitude, (orConditionDto.ConditionA as MagnitudeConditionDto).Magnitude);
            Assert.AreEqual(((result as OrConditionDto).ConditionB as ScaleConditionDto).Scale.X, (orConditionDto.ConditionB as ScaleConditionDto).Scale.X);
        }


	[Test]
        public void Clear()
        {
            _tree.Clear();
            Assert.AreEqual(ChildrenCount, _tree.Children.Count());
            Assert.AreEqual(0, _tree.Points.Connections.Count());
            Assert.AreEqual(0, _tree.Points.Count());
        }


        [Test]
        public void BoolValueInactiveGameObject()
        {
            subject.Timeline = animator;
            subject.ParameterName = "BoolTest";
            subject.gameObject.SetActive(false);
            Assert.IsFalse(animator.GetBool("BoolTest"));

            subject.BoolValue = true;

            Assert.IsFalse(animator.GetBool("BoolTest"));
            Assert.IsFalse(subject.BoolValue);
        }

        
             [UnityTest]                                                                                                                                    
     public IEnumerator ValidSurfaceDueToTargetPointValidity()                                                                                      
     {                                                                                                                                              
 UNITY_2022_2_OR_NEWER                                                                                                                              
         Physics.simulationMode = SimulationMode.FixedUpdate;                                                                                       
se                                                                                                                                                  
         Physics.autoSimulation = true;                                                                                                             
dif                                                                                                                                                 
                                                                                                                                                    
         GameObject validSurface = GameObject.CreatePrimitive(PrimitiveType.Cube);                                                                  
         GameObject searchOrigin = new GameObject("SearchOrigin");                                                                                  
                                                                                                                                                    
         UnityEventListenerMock surfaceLocatedMock = new UnityEventListenerMock();                                                                  
         subject.SurfaceLocated.AddListener(surfaceLocatedMock.Listen);                                                                             
                                                                                                                                                    
         validSurface.transform.position = Vector3.forward * 5f;                                                                                    
         Vector3RuleStub vector3Point = validSurface.AddComponent<Vector3RuleStub>();                                                               
         vector3Point.toMatch = validSurface.transform.position - (Vector3.forward * validSurface.transform.localScale.z * 0.5f);                   
         yield return null;                                                                                                                         
                                                                                                                                                    
         subject.TargetPointValidity = new RuleContainer                                                                                            
         {                                                                                                                                          
             Interface = vector3Point                                                                                                               
         };                                                                                                                                         
                                                                                                                                                    
         subject.SearchOrigin = searchOrigin;                                                                                                       
         subject.SearchDirection = Vector3.forward;                                                                                                 
                                                                                                                                                    
         yield return waitForFixedUpdate;                                                                                                           
         subject.Locate();                                                                                                                          
         yield return waitForFixedUpdate;                                                                                                           
         Assert.IsTrue(surfaceLocatedMock.Received);                                                                                                
         Assert.AreEqual(validSurface.transform, subject.surfaceData.Transform);                                                                    
                                                                                                                                                    
         Object.DestroyImmediate(validSurface);                                                                                                     
         Object.DestroyImmediate(searchOrigin);                                                                                                     
     }                                                                                                                                              
                                                                                                                                                    
     [UnityTest]                                                                                                                                    
     public IEnumerator MissingSurfaceDueToLocatorTermination()                                                                                     
     {                                                                                                                                              
 UNITY_2022_2_OR_NEWER                                                                                                                              
         Physics.simulationMode = SimulationMode.FixedUpdate;                                                                                       
se                                                                                                                                                  
         Physics.autoSimulation = true;                                                                                                             
dif                                                                                                                                                 
                                                                                                                                                    
         GameObject terminatingSurface = GameObject.CreatePrimitive(PrimitiveType.Cube);                                                            
         GameObject searchOrigin = new GameObject("SearchOrigin");                                                                                  
                                                                                                                                                    
         UnityEventListenerMock surfaceLocatedMock = new UnityEventListenerMock();                                                                  
         subject.SurfaceLocated.AddListener(surfaceLocatedMock.Listen);                                                                             
                                                                                                                                                    
         terminatingSurface.transform.position = Vector3.forward * 5f;                                                                              
         terminatingSurface.AddComponent<RuleStub>();                                                                                               
                                                                                                                                                    
         AnyComponentTypeRule anyComponentTypeRule = terminatingSurface.AddComponent<AnyComponentTypeRule>();                                       
         SerializableTypeComponentObservableList rules = containingObject.AddComponent<SerializableTypeComponentObservableList>();                  
         yield return null;                                                                                                                         
                                                                                                                                                    
         anyComponentTypeRule.ComponentTypes = rules;                                                                                               
         rules.Add(typeof(RuleStub));                                                                                                               
                                                                                                                                                    
         subject.LocatorTermination = new RuleContainer                                                                                             
         {                                                                                                                                          
             Interface = anyComponentTypeRule                                                                                                       
         };                                                                                                                                         
                                                                                                                                                    
         subject.SearchOrigin = searchOrigin;                                                                                                       
         subject.SearchDirection = Vector3.forward;                                                                                                 
                                                                                                                                                    
         yield return waitForFixedUpdate;                                                                                                           
         subject.Locate();                                                                                                                          
         yield return waitForFixedUpdate;                                                                                                           
         Assert.IsFalse(surfaceLocatedMock.Received);                                                                                               
         Assert.IsNull(subject.surfaceData.Transform);                                                                                              
                                                                                                                                                    
         Object.DestroyImmediate(terminatingSurface);                                                                                               
         Object.DestroyImmediate(searchOrigin);                                                                                                     
       }                                                                                                                                              
                                                                                                                                                    
        
        [TestMethod]
        public void RebroadcastServerManager_ConfigurationChanged_Disposes_Of_Old_And_Creates_New_Server_If_Format_Changes()
        {
            _Manager.Initialise();

            _RebroadcastSettings.Format = RebroadcastFormat.Port30003;
            _ConfigurationStorage.Raise(r => r.ConfigurationChanged += null, EventArgs.Empty);

            Assert.AreEqual(1, _Manager.RebroadcastServers.Count);
            Assert.AreEqual(RebroadcastFormat.Port30003, _Server.Object.Format);
            _Server.Verify(r => r.Dispose(), Times.Once());
            _Connector.Verify(r => r.Dispose(), Times.Once());
        }
      
        [Test]
        public static void TestUuid5()
        {
            // Test values computed using python uuid.uuid5
            Assert.AreEqual(GuidUtils.Uuid5(Guid.Empty, "fancy"),
                new Guid("f8893632-dedc-566d-83f1-afda8c3bbd31"));
            Assert.AreEqual(GuidUtils.Uuid5(GuidUtils.kNamespaceDns, "fancy"),
                new Guid("750c4490-5470-5f19-a5e9-98c1ce534c7e"));
        }

        
        [TestMethod]
        public void Listener_Connect_Moves_NonIcao24Address_To_Icao24_If_FineFormatTisB_With_Icao24_Address()
        {
            _Clock.UtcNowValue = new DateTime(2007, 8, 9, 10, 11, 12, 13);
            _Connector.ConfigureForConnect();
            _Connector.ConfigureForReadStream("a");
            _BytesExtractor.AddExtractedBytes(ExtractedBytesFormat.ModeS, 7);

            _ModeSMessage.DownlinkFormat = DownlinkFormat.ExtendedSquitterNonTransponder;
            _ModeSMessage.ControlField = ControlField.FineFormatTisb;
            _ModeSMessage.Icao24 = 0;
            _ModeSMessage.NonIcao24Address = 0xABCDEF;

            _AdsbMessage.TisbIcaoModeAFlag = 0;

            ChangeSourceAndConnect();

            Assert.AreEqual(0xABCDEF, _ModeSMessage.Icao24);
            Assert.AreEqual(null, _ModeSMessage.NonIcao24Address);
        }

        
        [Test]
        public void DefaultStateZAxis()
        {
            Vector3State actualResult = Vector3State.ZOnly;
            Assert.IsFalse(actualResult.xState);
            Assert.IsFalse(actualResult.yState);
            Assert.IsTrue(actualResult.zState);
        }
        
        [Test]
        public void ReceiveInactiveGameObject()
        {
            UnityEventListenerMock emittedMock = new UnityEventListenerMock();
            subject.Emitted.AddListener(emittedMock.Listen);
            subject.gameObject.SetActive(false);
            SurfaceData payload = new SurfaceData();

            Assert.IsNull(subject.Payload);
            Assert.IsFalse(emittedMock.Received);

            subject.Receive(payload);

            Assert.IsNull(subject.Payload);
            Assert.IsFalse(emittedMock.Received);
        }

        
       
        [Test]
        public void PopAtIndexMiddle()
        {
            UnityEventListenerMock elementOnePushedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementOnePoppedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementOneForcePoppedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementOneRestoredMock = new UnityEventListenerMock();
            GameObjectObservableStack.GameObjectElementEvents eventsOne = new GameObjectObservableStack.GameObjectElementEvents();
            eventsOne.Pushed.AddListener(elementOnePushedMock.Listen);
            eventsOne.Popped.AddListener(elementOnePoppedMock.Listen);
            eventsOne.ForcePopped.AddListener(elementOneForcePoppedMock.Listen);
            eventsOne.Restored.AddListener(elementOneRestoredMock.Listen);

            UnityEventListenerMock elementTwoPushedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementTwoPoppedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementTwoForcePoppedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementTwoRestoredMock = new UnityEventListenerMock();
            GameObjectObservableStack.GameObjectElementEvents eventsTwo = new GameObjectObservableStack.GameObjectElementEvents();
            eventsTwo.Pushed.AddListener(elementTwoPushedMock.Listen);
            eventsTwo.Popped.AddListener(elementTwoPoppedMock.Listen);
            eventsTwo.ForcePopped.AddListener(elementTwoForcePoppedMock.Listen);
            eventsTwo.Restored.AddListener(elementTwoRestoredMock.Listen);

            UnityEventListenerMock elementThreePushedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementThreePoppedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementThreeForcePoppedMock = new UnityEventListenerMock();
            UnityEventListenerMock elementThreeRestoredMock = new UnityEventListenerMock();
            GameObjectObservableStack.GameObjectElementEvents eventsThree = new GameObjectObservableStack.GameObjectElementEvents();
            eventsThree.Pushed.AddListener(elementThreePushedMock.Listen);
            eventsThree.Popped.AddListener(elementThreePoppedMock.Listen);
            eventsThree.ForcePopped.AddListener(elementThreeForcePoppedMock.Listen);
            eventsThree.Restored.AddListener(elementThreeRestoredMock.Listen);

            GameObject objectOne = new GameObject("GameObjectEventObservableTest");
            GameObject objectTwo = new GameObject("GameObjectEventObservableTest");
            GameObject objectThree = new GameObject("GameObjectEventObservableTest");

            subject.ElementEvents.Add(eventsOne);
            subject.ElementEvents.Add(eventsTwo);
            subject.ElementEvents.Add(eventsThree);

            subject.Push(objectOne);
            subject.Push(objectTwo);
            subject.Push(objectThree);

            elementOnePushedMock.Reset();
            elementOnePoppedMock.Reset();
            elementOneForcePoppedMock.Reset();
            elementTwoPushedMock.Reset();
            elementTwoPoppedMock.Reset();
            elementTwoForcePoppedMock.Reset();
            elementThreePushedMock.Reset();
            elementThreePoppedMock.Reset();
            elementThreeForcePoppedMock.Reset();

            Assert.IsFalse(elementOnePushedMock.Received);
            Assert.IsFalse(elementOnePoppedMock.Received);
            Assert.IsFalse(elementOneForcePoppedMock.Received);
            Assert.IsFalse(elementOneRestoredMock.Received);
            Assert.IsFalse(elementTwoPushedMock.Received);
            Assert.IsFalse(elementTwoPoppedMock.Received);
            Assert.IsFalse(elementTwoForcePoppedMock.Received);
            Assert.IsFalse(elementTwoRestoredMock.Received);
            Assert.IsFalse(elementThreePushedMock.Received);
            Assert.IsFalse(elementThreePoppedMock.Received);
            Assert.IsFalse(elementThreeForcePoppedMock.Received);
            Assert.IsFalse(elementThreeRestoredMock.Received);

            subject.PopAt(1);

            Assert.IsFalse(elementOnePushedMock.Received);
            Assert.IsFalse(elementOnePoppedMock.Received);
            Assert.IsFalse(elementOneForcePoppedMock.Received);
            Assert.IsTrue(elementOneRestoredMock.Received);
            Assert.IsFalse(elementTwoPushedMock.Received);
            Assert.IsTrue(elementTwoPoppedMock.Received);
            Assert.IsFalse(elementTwoForcePoppedMock.Received);
            Assert.IsFalse(elementTwoRestoredMock.Received);
            Assert.IsFalse(elementThreePushedMock.Received);
            Assert.IsFalse(elementThreePoppedMock.Received);
            Assert.IsTrue(elementThreeForcePoppedMock.Received);
            Assert.IsFalse(elementThreeRestoredMock.Received);

            Object.DestroyImmediate(objectOne);
            Object.DestroyImmediate(objectTwo);
            Object.DestroyImmediate(objectThree);
        }
        
        [TestMethod]
        public void RawMessageTranslator_Translate_Extracts_VerticalRate_From_ADSB_Messages()
        {
            foreach(var adsbMessage in CreateAdsbMessagesForExtendedSquitters()) {
                foreach(var rateIsBarometric in new bool[] { true, false }) {
                    var airborneVelocity = adsbMessage.AirborneVelocity = new AirborneVelocityMessage();
                    airborneVelocity.VerticalRate = 100;
                    airborneVelocity.VerticalRateIsBarometric = rateIsBarometric;

                    var message = _Translator.Translate(_NowUtc, adsbMessage.ModeSMessage, adsbMessage);

                    Assert.AreEqual(100, message.VerticalRate);
                    if(rateIsBarometric) Assert.IsTrue(message.Supplementary.VerticalRateIsGeometric.GetValueOrDefault());
                    else if(message.Supplementary != null) Assert.IsFalse(message.Supplementary.VerticalRateIsGeometric.GetValueOrDefault());
                }
            }
        }

       
        [TestMethod]
        public void ReportRows_RegistrationReport_Deals_With_Missing_Aircraft_Criteria_Correctly()
        {
            _ReportRowsAddress.Report = "reg";

            var json = SendJsonRequest<AircraftReportJson>(_ReportRowsAddress.Address);

            _BaseStationDatabase.Verify(db => db.GetAircraftByRegistration(It.IsAny<string>()), Times.Never());

            Assert.AreEqual(0, json.CountRows);
            Assert.AreEqual(0, json.Flights.Count);
            Assert.AreEqual(0, json.Airports.Count);
            Assert.AreEqual(0, json.Routes.Count);
            Assert.IsTrue(json.Aircraft.IsUnknown);
        }
      
 
       
        [Test]
        public void TestGetAngleBetween()
        {
            int kNumTests = 30;
            int kNumOffsets = 5;
            // Test doesn't do a good job of avoiding instability, so just crank this up
            // in lieu of doing a more precise job (eg, by using the "stability" output)
            float kEpsilon = 5e-2f;

            for (int iTest = 0; iTest < kNumTests; ++iTest)
            {
                Vector3 axis = Random.onUnitSphere;
                float angle = Random.Range(-179f, 179f);
                // test too unstable; should write a better one if we need to test precision
                if (angle < 1f) { continue; }
                Quaternion q = Quaternion.AngleAxis(angle, axis);

                Vector3 v0 = Random.onUnitSphere;
                Vector3 v1 = q * v0;
                for (int iOffset = 0; iOffset < kNumOffsets; ++iOffset)
                {
                    float stability;
                    Vector3 v0p = v0 + Random.Range(-100f, 100f) * axis;
                    Vector3 v1p = v1 + Random.Range(-100f, 100f) * axis;
                    float result = MathUtils.GetAngleBetween(v0p, v1p, axis, out stability);
                    Assert.AreEqual(angle, result, kEpsilon);
                    result = MathUtils.GetAngleBetween(v1, v0, axis, out stability);
                    Assert.AreEqual(angle, -result, kEpsilon);
                }
            }
        }

        const float kLeft = -1;
        const float kRight = 2;
        const float kBottom = -2;
        const float kTop = 6;
        const float kNear = 1;
        const float kFar = 10;
        static readonly Matrix4x4 kOffCenter = MathUtils.PerspectiveOffCenter(
            kLeft, kRight, kBottom, kTop, kNear, kNear, kFar);
        // Runs v through projection matrix, returns NDC
        static Vector3 Project(float x, float y, float z)
        {
            // Note that by convention, perspective matrices are right-handed,
            // with x = right, y = up, -z = forward
            Vector4 clip = kOffCenter * new Vector4(x, y, z, 1);
            var v = new Vector3(clip.x, clip.y, clip.z) / clip.w;
            return v;
        }


	
        [Test]
        public void CastPointsDragEffectDensity()
        {
            subject.Origin = subject.gameObject;

            validSurface.transform.position = Vector3.forward * 5f;

            subject.ManualOnEnable();
            Physics.Simulate(Time.fixedDeltaTime);
            subject.Process();
            Assert.AreEqual(2, subject.Points.Count);

            subject.DragEffectDensity = 7;
            subject.Process();
            Assert.AreEqual(10, subject.Points.Count);
        }


         [Test]
         public void RawMessageTranslator_Translate_Extracts_VerticalRate_From_ADSB_Messages()
        {
            foreach(var adsbMessage in CreateAdsbMessagesForExtendedSquitters()) {
                foreach(var rateIsBarometric in new bool[] { true, false }) {
                    var airborneVelocity = adsbMessage.AirborneVelocity = new AirborneVelocityMessage();
                    airborneVelocity.VerticalRate = 100;
                    airborneVelocity.VerticalRateIsBarometric = rateIsBarometric;

                    var message = _Translator.Translate(_NowUtc, adsbMessage.ModeSMessage, adsbMessage);

                    Assert.AreEqual(100, message.VerticalRate);
                    if(rateIsBarometric) Assert.IsTrue(message.Supplementary.VerticalRateIsGeometric.GetValueOrDefault());
                    else if(message.Supplementary != null) Assert.IsFalse(message.Supplementary.VerticalRateIsGeometric.GetValueOrDefault());
                }
            }
        }
        #endregion



        [Test]
        public void TransformOverBounds()
        {
            UnityEventListenerMock transformedListenerMock = new UnityEventListenerMock();
            subject.Transformed.AddListener(transformedListenerMock.Listen);
            subject.SetRange(new Vector2(0f, 10f));

            Assert.AreEqual(0f, subject.Result);
            Assert.IsFalse(transformedListenerMock.Received);

            float expected = 1f;
            float result = subject.Transform(15f);

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected, subject.Result);
            Assert.IsTrue(transformedListenerMock.Received);
        }

        
        [Test]
        public void Process()
        {
            QuaternionEqualityComparer comparer = new QuaternionEqualityComparer(0.1f);
            GameObject target = new GameObject("DirectionModifierTest");
            GameObject lookAt = new GameObject("DirectionModifierTest");
            GameObject pivot = new GameObject("DirectionModifierTest");

            subject.Target = target;
            subject.LookAt = lookAt;
            subject.Pivot = pivot;

            lookAt.transform.position = Vector3.up * 2f;
            pivot.transform.position = Vector3.back * 0.5f;

            Assert.That(target.transform.rotation, Is.EqualTo(Quaternion.identity).Using(comparer));

            subject.Process();

            Assert.That(target.transform.rotation, Is.EqualTo(new Quaternion(-0.6f, 0.0f, 0.0f, 0.8f)).Using(comparer));

            Object.DestroyImmediate(target);
            Object.DestroyImmediate(lookAt);
            Object.DestroyImmediate(pivot);
        }

         
        [TestMethod]
        public void Listener_Connect_Does_Not_Translate_Null_ModeS_Messages()
        {
            _Connector.ConfigureForConnect();
            _Connector.ConfigureForReadStream("a");
            _BytesExtractor.AddExtractedBytes(ExtractedBytesFormat.ModeS, 7);
            _ModeSTranslator.Setup(r => r.Translate(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<bool>())).Returns((ModeSMessage)null);

            ChangeSourceAndConnect();

            _ModeSTranslator.Verify(r => r.Translate(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int?>(), It.IsAny<bool>()), Times.Once());
            _AdsbTranslator.Verify(r => r.Translate(It.IsAny<ModeSMessage>()), Times.Never());
            _RawMessageTranslator.Verify(r => r.Translate(It.IsAny<DateTime>(), It.IsAny<ModeSMessage>(), It.IsAny<AdsbMessage>()), Times.Never());
            Assert.AreEqual(0, _ModeSMessageReceivedEvent.CallCount);
            Assert.AreEqual(0, _Port30003MessageReceivedEvent.CallCount);
        }


        [UnityTest]
        public IEnumerator ProcessFirstActiveSourceAgainstValidTargetThenCease()
        {
            GameObject source1 = new GameObject("source1");
            GameObject source2 = new GameObject("source2");
            GameObject source3 = new GameObject("source3");
            GameObject target1 = new GameObject("target1");
            GameObject target2 = new GameObject("target2");
            GameObject target3 = new GameObject("target3");
            subject.Sources = containingObject.AddComponent<GameObjectObservableList>();
            subject.Targets = containingObject.AddComponent<GameObjectObservableList>();
            yield return null;

            subject.CeaseAfterFirstSourceProcessed = true;

            subject.gameObject.AddComponent<RuleStub>();
            ActiveInHierarchyRule activeInHierarchyRule = subject.gameObject.AddComponent<ActiveInHierarchyRule>();
            subject.SourceValidity = new RuleContainer
            {
                Interface = activeInHierarchyRule
            };
            subject.TargetValidity = new RuleContainer
            {
                Interface = activeInHierarchyRule
            };

            subject.Sources.Add(source1);
            subject.Sources.Add(source2);
            subject.Sources.Add(source3);
            subject.Targets.Add(target1);
            subject.Targets.Add(target2);
            subject.Targets.Add(target3);

            Assert.AreEqual("source1", source1.name);
            Assert.AreEqual("source2", source2.name);
            Assert.AreEqual("source3", source3.name);
            Assert.AreEqual("target1", target1.name);
            Assert.AreEqual("target2", target2.name);
            Assert.AreEqual("target3", target3.name);

            source1.SetActive(false);
            source2.SetActive(true);
            source3.SetActive(true);

            target1.SetActive(false);
            target2.SetActive(true);
            target3.SetActive(true);

            subject.Process();

            Assert.AreEqual("source1", source1.name);
            Assert.AreEqual("source2", source2.name);
            Assert.AreEqual("source3", source3.name);
            Assert.AreEqual("target1", target1.name);
            Assert.AreEqual("source2", target2.name);
            Assert.AreEqual("source2", target3.name);

            source1.SetActive(false);
            source2.SetActive(false);
            source3.SetActive(true);

            target1.SetActive(false);
            target2.SetActive(true);
            target3.SetActive(false);

            subject.Process();

            Assert.AreEqual("source1", source1.name);
            Assert.AreEqual("source2", source2.name);
            Assert.AreEqual("source3", source3.name);
            Assert.AreEqual("target1", target1.name);
            Assert.AreEqual("source3", target2.name);
            Assert.AreEqual("source2", target3.name);

            source1.SetActive(true);
            source2.SetActive(true);
            source3.SetActive(true);

            target1.SetActive(true);
            target2.SetActive(true);
            target3.SetActive(true);

            subject.Process();

            Assert.AreEqual("source1", source1.name);
            Assert.AreEqual("source2", source2.name);
            Assert.AreEqual("source3", source3.name);
            Assert.AreEqual("source1", target1.name);
            Assert.AreEqual("source1", target2.name);
            Assert.AreEqual("source1", target3.name);

            Object.DestroyImmediate(source1);
            Object.DestroyImmediate(source2);
            Object.DestroyImmediate(source3);
            Object.DestroyImmediate(target1);
            Object.DestroyImmediate(target2);
            Object.DestroyImmediate(target3);
        }

        [Test]
        public void Update()
        {
            var block = new CollisionBlock(Vector3Int.zero);
            block.AddItem(0, Vector3.left);
            
            var ray = new Ray(Vector3.zero, Vector3.left);
            Assert.AreEqual(0, block.FindItem(ray, 0.2f).Value);

            block.UpdateItem(0, Vector3.left, Vector3.one);
            Assert.IsFalse(block.FindItem(ray, 0.2f).HasValue);
            
            ray = new Ray(Vector3.zero, Vector3.one);
            Assert.AreEqual(0, block.FindItem(ray, 0.2f).Value);
        }

        
        [TestMethod]
        public void RawMessageTranslator_Translate_Extracts_GroundSpeed_From_Adsb_Surface_Position_Messages()
        {
            foreach(var adsbMessage in CreateAdsbMessagesForExtendedSquitters()) {
                foreach(var isReversing in new bool[] { true, false }) {
                    adsbMessage.SurfacePosition = new SurfacePositionMessage() { GroundSpeed = 123, IsReversing = isReversing };

                    var message = _Translator.Translate(_NowUtc, adsbMessage.ModeSMessage, adsbMessage);

                    Assert.AreEqual(123F, message.GroundSpeed);
                    if(isReversing) Assert.AreEqual(SpeedType.GroundSpeedReversing, message.Supplementary.SpeedType);
                    else {
                        if(message.Supplementary != null) Assert.AreEqual(SpeedType.GroundSpeed, message.Supplementary.SpeedType);
                    }
                }
            }
        }

        
        [Test]
        public void SetBrushOnPatchObject() {
            Brush brush = this.Patch.GetBrush();
            brush.SketchMaterial.AlbedoColor = Color.magenta;
            Assert.AreNotEqual(Color.magenta, this.Patch.GetComponent<MeshRenderer>().sharedMaterial.color);

            ICommand SetBrushCommand = new SetBrushCommand(this.Patch, brush);
            Invoker.ExecuteCommand(SetBrushCommand);

            Assert.AreEqual(Color.magenta, this.Patch.GetComponent<MeshRenderer>().sharedMaterial.color);
        }
       
        
        [Test]
        public void WriteRead_NodeBinding()
        {
            NodeBindingDataDto bindingDataDto = new NodeBindingDataDto()
            {
                parentNodeId = 12,
                syncPosition = false,
                syncRotation = false,
                syncScale = false,
                offSetPosition = Vector3.zero.Dto(),
                offSetRotation = Quaternion.identity.Dto(),
                offSetScale = Vector3.one.Dto(),
                anchorPosition = Vector3.zero.Dto(),
                priority = 10,
                partialFit = true
            };

            BindingDto bindingDto = new BindingDto()
            {
                boundNodeId = 123,
                data = bindingDataDto
            };

            Bytable data = UMI3DSerializer.Write(bindingDto);

            ByteContainer byteContainer = new ByteContainer(0,1, data.ToBytes());

            bool readable = UMI3DSerializer.TryRead(byteContainer, out BindingDto result);

            Assert.IsTrue(readable, "Object deserialization failed.");
            Assert.AreEqual(bindingDto.boundNodeId, result.boundNodeId);

            Assert.AreEqual(bindingDto.data.priority, result.data.priority);
            Assert.AreEqual(bindingDto.data.partialFit, result.data.partialFit);

            var simpleBindingDataDto = bindingDto.data as AbstractSimpleBindingDataDto;
            var resultSimpleBindingDataDto = result.data as AbstractSimpleBindingDataDto;
            Assert.AreEqual(simpleBindingDataDto.syncPosition,      resultSimpleBindingDataDto.syncPosition);
            Assert.AreEqual(simpleBindingDataDto.syncRotation,      resultSimpleBindingDataDto.syncRotation);
            Assert.AreEqual(simpleBindingDataDto.syncScale,         resultSimpleBindingDataDto.syncScale);
            Assert.AreEqual(simpleBindingDataDto.offSetPosition.Struct(),    resultSimpleBindingDataDto.offSetPosition.Struct());
            Assert.AreEqual(simpleBindingDataDto.offSetRotation.Struct(),    resultSimpleBindingDataDto.offSetRotation.Struct());
            Assert.AreEqual(simpleBindingDataDto.offSetScale.Struct(),       resultSimpleBindingDataDto.offSetScale.Struct());

            var nodeBindingDataDto = bindingDto.data as NodeBindingDataDto;
            var resultNodeBindingDataDto = result.data as NodeBindingDataDto;
            Assert.AreEqual(nodeBindingDataDto.parentNodeId, resultNodeBindingDataDto.parentNodeId);
        }

        
        [Test]
        public void OnAfterDeserializeMakeFillOriginZeroIfNotBetweenZeroAndThree()
        {
            for (int i = -10; i < 0; i++)
            {
                m_Image.fillOrigin = i;
                m_Image.OnAfterDeserialize();
                Assert.AreEqual(0, m_Image.fillOrigin);
            }

            for (int i = 0; i < 4; i++)
            {
                m_Image.fillOrigin = i;
                m_Image.OnAfterDeserialize();
                Assert.AreEqual(i, m_Image.fillOrigin);
            }

            for (int i = 4; i < 10; i++)
            {
                m_Image.fillOrigin = i;
                m_Image.OnAfterDeserialize();
                Assert.AreEqual(0, m_Image.fillOrigin);
            }
        }
        
        
        [TestMethod]
        public void RebroadcastServer_Honours_Offset_And_Length_For_ModeS_Bytes()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            SetupForAvr();

            _Listener.Raise(r => r.ModeSBytesReceived += null, new EventArgs<ExtractedBytes>(new ExtractedBytes() { Bytes = bytes, Offset = 1, Length = bytes.Length - 1, Format = ExtractedBytesFormat.ModeS, HasParity = true }));

            Assert.AreEqual(1, _Connector.Written.Count);
            Assert.AreEqual("*020304;\r\n", Encoding.ASCII.GetString(_Connector.Written[0]));
        }

       
        
    [Test]
    public void RemoveAtTest1() {
      addOneOfEach();
      Assert.That(_list.Count, Is.EqualTo(8));

      for (int i = 0; i < 8; i++) {
        _list.RemoveAt(0);
      }

      Assert.That(_list.Count, Is.EqualTo(0));
    }
 

      
        [Test]
        public void InvalidLocateSameSurface()
        {
            GameObject validSurface = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject searchOrigin = new GameObject("SearchOrigin");

            UnityEventListenerMock surfaceLocatedMock = new UnityEventListenerMock();
            subject.SurfaceLocated.AddListener(surfaceLocatedMock.Listen);

            validSurface.transform.position = Vector3.forward * 5f;

            subject.SearchOrigin = searchOrigin;
            subject.SearchDirection = Vector3.forward;

            //Process just calls Locate() so may as well just test the first point
            Physics.Simulate(Time.fixedDeltaTime);
            subject.Process();

            Assert.IsTrue(surfaceLocatedMock.Received);
            Assert.AreEqual(validSurface.transform, subject.surfaceData.Transform);

            surfaceLocatedMock.Reset();

            subject.Process();

            Assert.IsFalse(surfaceLocatedMock.Received);
            Assert.AreEqual(validSurface.transform, subject.surfaceData.Transform);

            Object.DestroyImmediate(validSurface);
            Object.DestroyImmediate(searchOrigin);
        }

        
        [TestMethod]
        public void RawMessageTranslator_Translate_Extracts_GroundSpeed_From_Adsb_Surface_Position_Messages()
        {
            foreach(var adsbMessage in CreateAdsbMessagesForExtendedSquitters()) {
                foreach(var isReversing in new bool[] { true, false }) {
                    adsbMessage.SurfacePosition = new SurfacePositionMessage() { GroundSpeed = 123, IsReversing = isReversing };

                    var message = _Translator.Translate(_NowUtc, adsbMessage.ModeSMessage, adsbMessage);

                    Assert.AreEqual(123F, message.GroundSpeed);
                    if(isReversing) Assert.AreEqual(SpeedType.GroundSpeedReversing, message.Supplementary.SpeedType);
                    else {
                        if(message.Supplementary != null) Assert.AreEqual(SpeedType.GroundSpeed, message.Supplementary.SpeedType);
                    }
                }
            }
        }

        [TestMethod]
        public void Cidr_Default_Constructor_Initialises_To_Known_State()
        {
            var cidr = new Cidr();
            Assert.AreEqual(IPAddress.None, cidr.Address);
            Assert.AreEqual(IPAddress.Parse("0.0.0.0"), cidr.MaskedAddress);
            Assert.AreEqual(0, cidr.BitmaskBits);
            Assert.AreEqual((uint)0, cidr.IPv4Bitmask);
        }
        #endregion


        
        [Test]
        public void TestOverflowCacheWithSmallerItem()
        {
            var cache = new LRUCache<UUID, string>(10);
            string testData = "Test Data";

            for (int i = 0; i < 10; i++)
            {
                var id = UUID.Random();
                cache.Add(id, testData);
            }

            Assert.AreEqual(10, cache.Count, "Count property was wrong");
            Assert.AreEqual(10, cache.Size, "Size property was wrong");

            UUID overflowId = UUID.Random();
            string overflowData = "OverFlow";
            cache.Add(overflowId, overflowData);

            Assert.AreEqual(10, cache.Count, "Count property was wrong");
            Assert.AreEqual(10, cache.Size, "Size property was wrong");

            Assert.IsTrue(cache.TryGetValue(overflowId, out string lastInsertedValue));
            Assert.AreEqual(overflowData, lastInsertedValue);
        }

        
        [Test]
        public void DeleteObjectsOfSelectionCommand() {
            GameObject bounds = null;
            foreach (Transform transform in this.Selection.transform)
            {
                if (transform.name == "BoundsVisualizationObject")
                {
                    bounds = transform.gameObject;
                }
            }

            Assert.IsFalse(bounds.activeInHierarchy);
            this.Selection.AddToSelection(this.Ribbon);
            ICommand activateCommand = new ActivateSelectionCommand(this.Selection);
            Invoker.ExecuteCommand(activateCommand);
            ICommand deleteCommand = new DeleteObjectsOfSelectionCommand(this.Selection);
            Invoker.ExecuteCommand(deleteCommand);

            Assert.IsFalse(this.Ribbon.transform.IsChildOf(this.Selection.transform));
            Assert.IsFalse(bounds.activeInHierarchy);
            Assert.AreNotEqual("HighlightSelectionMaterial (Instance)", this.Ribbon.GetComponent<MeshRenderer>().material.name);
            Assert.IsTrue(this.Ribbon.transform.IsChildOf(SketchWorld.ActiveSketchWorld.transform));
        }

        
	[Test]
	public void TestEnvironment_StartPlayerInTestMode_PlayerStarted() {
		FirstPersonController player = GameObject.FindObjectOfType<FirstPersonController> ();
		Assert.IsFalse (player.HasStarted(), "Player shouldn't have started yet");
		player.testMode = true;
		player.TestStart ();
		Assert.IsTrue (player.HasStarted(), "Player should have started");
	}



   
        [Test]
        public void CreateSkeleton_NullParent()
        {
            // GIVEN
            ulong userId = 1005uL;
            UserDto userDto = new UserDto() { id = userId };
            UMI3DUser user = new UMI3DUser(UMI3DGlobalID.EnvironmentId, userDto);
            var userList = new List<UMI3DUser>() { user };


            UMI3DSkeletonHierarchy hierarchy = HierarchyTestHelper.CreateTestHierarchy();

            var parameterMock = new Mock<IUMI3DCollabLoadingParameters>();
            parameterMock.Setup(x => x.CollabTrackedSkeleton).Returns(trackedSubskeletonGo);
            collaborativeLoaderServiceMock.Setup(x => x.AbstractLoadingParameters).Returns(parameterMock.Object);
            collaborativeEnvironmentManagementServiceMock.Setup(x => x.UserList).Returns(userList);

            // WHEN
            var skeleton = collaborativeSkeletonManager.CreateSkeleton(UMI3DGlobalID.EnvironmentId, userId, null, hierarchy);

            // THEN
            Assert.IsNotNull(skeleton);
            Assert.AreEqual(userId, skeleton.UserId);

            Assert.Greater(skeleton.Bones.Count, 0);
            Assert.IsNotNull(skeleton.SkeletonHierarchy);
            Assert.IsNotNull(skeleton.HipsAnchor);
            Assert.IsNotNull(skeleton.transform.parent);

            Assert.IsNotNull(skeleton.PoseSubskeleton);
            Assert.IsNotNull(skeleton.TrackedSubskeleton);
        }


        
        [TestMethod]
        public void StandingDataManager_FindAircraftType_Can_Find_By_Type_Code_With_Multiple_Models()
        {
            _Implementation.Load();

            var type = _Implementation.FindAircraftType("D11");
            Assert.AreEqual(2, type.Models.Count);
            Assert.AreEqual(2, type.Manufacturers.Count);
            Assert.AreEqual("FALCONAR", type.Manufacturers[0]);
            Assert.AreEqual("FALCONAR", type.Manufacturers[1]);
            Assert.IsTrue(type.Models.Contains("Cruiser"));
            Assert.IsTrue(type.Models.Contains("F-11"));
            Assert.AreEqual("D11", type.Type);
            Assert.AreEqual(WakeTurbulenceCategory.Light, type.WakeTurbulenceCategory);
            Assert.AreEqual(Species.Landplane, type.Species);
            Assert.AreEqual(EngineType.Piston, type.EngineType);
            Assert.AreEqual("1", type.Engines);
        }


        
        [Test]
        public void NoModifyPositionOnInactiveGameObject()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            sourceTransformData.Transform.position = Vector3.one;

            subject.Source = new TransformData(sourceObject);
            subject.Target = targetObject;
            subject.ApplyTransformations = TransformProperties.Position;
            sourceTransformData.Transform.position = Vector3.one;
            subject.gameObject.SetActive(false);

            Assert.That(targetObject.transform.position, Is.EqualTo(Vector3.zero).Using(comparer));
            subject.Apply();
            Assert.That(targetObject.transform.position, Is.EqualTo(Vector3.zero).Using(comparer));
        }


        
        [TestMethod]
        public void MergedFeedListener_SetListener_Passes_Through_True_IsSatcomFeed_From_Nominated_Receiver()
        {
            _MergedFeed.IsSatcomFeed = false;
            _Listener1.Object.IsSatcomFeed = true;
            _MergedFeed.SetListeners(_Components);
            _MergedFeed.Port30003MessageReceived += _BaseStationMessageEventRecorder.Handler;

            var args = new BaseStationMessageEventArgs(new BaseStationMessage());
            _Listener1.Raise(r => r.Port30003MessageReceived += null, args);

            Assert.AreEqual(1, _BaseStationMessageEventRecorder.CallCount);
            Assert.AreEqual(true, _BaseStationMessageEventRecorder.Args.IsSatcomFeed);
        }
        
        
        [Test]
        public void ClearRightControllerInactiveGameObject()
        {
            DeviceDetailsRecordMock RightController = containingObject.AddComponent<DeviceDetailsRecordMock>();
            Assert.IsNull(subject.RightController);
            subject.RightController = RightController;
            Assert.AreEqual(RightController, subject.RightController);
            subject.gameObject.SetActive(false);
            subject.ClearRightController();
            Assert.AreEqual(RightController, subject.RightController);
        }

        
        [Test]
        public void ConvertFromRaycast()
        {
            caster.ConvertTo = subject;
            bool result = caster.CustomRaycast(new Ray(Vector3.zero, Vector3.forward), out RaycastHit missData, 10f);
            Assert.IsFalse(result);
            Assert.IsNull(missData.transform);
        }


        [Test]
        public void Test_02_ConfirmExtensionServiceProviderConfigurationPresent()
        {
            SetupServiceLocator();
            var profile = MixedRealityToolkit.Instance.ActiveProfile.RegisteredServiceProvidersProfile;
            var dataProviderTypes = new[] { typeof(TestExtensionService1) };
            var newConfig = new MixedRealityServiceConfiguration<IMixedRealityExtensionService>(typeof(TestExtensionService1), "Test Extension Service 1", 2, testPlatforms, null);
            Debug.Assert(newConfig != null);
            var newConfigs = profile.RegisteredServiceConfigurations.AddItem(newConfig);
            Debug.Assert(newConfigs != null);
            profile.RegisteredServiceConfigurations = newConfigs;
            Assert.IsTrue(profile.ValidateService(dataProviderTypes, newConfigs, false));
        }

        
    [Test]
    [TestCaseSource("textWithWordStartAndEndIndices")]
    [TestCaseSource("textWithWordStartAndEndIndicesWherePunctuationIsAWord")]
    public void DeleteWordBack_DeletesBackToPreviousWordStart(string text, int[] wordStartIndices, int[] wordEndIndices)
    {
        for (var index = 0; index <= text.Length; index++)
        {
            m_TextEditor.text = text;
            m_TextEditor.cursorIndex = m_TextEditor.selectIndex = index;
            var oldCursorIndex = m_TextEditor.cursorIndex;
            var oldSelectIndex = m_TextEditor.selectIndex;

            m_TextEditor.DeleteWordBack();

            var previousWordStart = wordStartIndices.Reverse().FirstOrDefault(i => i < oldCursorIndex);
            Assert.AreEqual(previousWordStart, m_TextEditor.cursorIndex, string.Format("cursorIndex {0} did not move to previous word start", oldCursorIndex));
            Assert.AreEqual(previousWordStart, m_TextEditor.selectIndex, string.Format("selectIndex {0} did not move to previous word start", oldSelectIndex));
            Assert.AreEqual(text.Remove(previousWordStart, oldCursorIndex - previousWordStart), m_TextEditor.text, string.Format("wrong resulting text for cursorIndex {0}", oldCursorIndex));
        }
    }

    
        [TestMethod]
        [DataSource("Data Source='WebSiteTests.xls';Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Extended Properties='Excel 8.0'",
                    "AircraftListCoordinates$")]
        public void AircraftListJsonBuilder_Builds_Arrays_Of_Trail_Coordinates_Correctly()
        {
            var worksheet = new ExcelWorksheetData(TestContext);

            AddBlankAircraft(1);
            var aircraft = _AircraftLists[0][0];
            Mock<IAircraft> mockAircraft = Mock.Get(aircraft);

            aircraft.Latitude = worksheet.NFloat("ACLat");
            aircraft.Longitude = worksheet.NFloat("ACLng");
            aircraft.Track = worksheet.NFloat("ACTrk");
            aircraft.FirstCoordinateChanged = worksheet.Long("ACFirstCoCh");
            aircraft.LastCoordinateChanged = worksheet.Long("ACLastCoCh");
            aircraft.PositionTime = new DateTime(1970, 1, 1, 0, 0, 0, worksheet.Int("ACPosTimeCh"));
            mockAircraft.Setup(m => m.PositionTimeChanged).Returns(worksheet.Long("ACPosTimeCh"));

            for(int i = 1;i <= 2;++i) {
                var dataVersion = String.Format("Coord{0}DV", i);
                var tick = String.Format("Coord{0}Tick", i);
                var latitude = String.Format("Coord{0}Lat", i);
                var longitude = String.Format("Coord{0}Lng", i);
                var track = String.Format("Coord{0}Trk", i);
                if(worksheet.String(dataVersion) != null) {
                    DateTime dotNetDate = new DateTime(1970, 1, 1, 0, 0, 0, worksheet.Int(tick));
                    var coordinate = new Coordinate(worksheet.Long(dataVersion), dotNetDate.Ticks, worksheet.Float(latitude), worksheet.Float(longitude), worksheet.NFloat(track));
                    aircraft.FullCoordinates.Add(coordinate);
                    aircraft.ShortCoordinates.Add(coordinate);
                }
            }

            _Args.TrailType = worksheet.Bool("ArgsShort") ? TrailType.Short : TrailType.Full;
            _Args.PreviousDataVersion = worksheet.Long("ArgsPrevDV");
            if(worksheet.Bool("ArgsIsPrevAC")) _Args.PreviousAircraft.Add(0);
            _Args.ResendTrails = worksheet.Bool("ArgsResend");

            var aircraftJson = _Builder.Build(_Args, ignoreInvisibleFeeds: true, fallbackToDefaultFeed: true).Aircraft[0];

            var count = worksheet.Int("Count");
            if(count == 0) {
                Assert.IsNull(aircraftJson.ShortCoordinates);
                Assert.IsNull(aircraftJson.FullCoordinates);
            } else {
                var list = worksheet.Bool("IsShort") ? aircraftJson.ShortCoordinates : aircraftJson.FullCoordinates;
                Assert.AreEqual(count, list.Count);
                for(int i = 0;i < count;++i) {
                    var column = String.Format("R{0}", i);
                    Assert.AreEqual(worksheet.NDouble(column), list[i], "Element {0}", i);
                }
            }

            Assert.AreEqual(worksheet.Bool("ResetTrail"), aircraftJson.ResetTrail);
        }


        

        [Test]
        public void SetAtEmptyCollection()
        {
            UnityEventListenerMock addedMock = new UnityEventListenerMock();
            UnityEventListenerMock removedMock = new UnityEventListenerMock();
            subject.Added.AddListener(addedMock.Listen);
            subject.Removed.AddListener(removedMock.Listen);

            GameObject elementOne = new GameObject("One");

            Assert.AreEqual(0, subject.NonSubscribableElements.Count);

            subject.SetAt(elementOne, 1);

            Assert.AreEqual(0, subject.NonSubscribableElements.Count);

            Assert.IsFalse(addedMock.Received);
            Assert.IsFalse(removedMock.Received);

            Object.DestroyImmediate(elementOne);
        }


        
        [TestMethod]
        public void ReportRows_RegistrationReport_Copes_When_Aircraft_Cannot_Be_Found()
        {
            _ReportRowsAddress.Report = "reg";
            _ReportRowsAddress.Registration = new StringFilter("ABC", FilterCondition.Equals, false);

            _BaseStationDatabase.Setup(db => db.GetAircraftByRegistration("ABC")).Returns((BaseStationAircraft)null);

            var json = SendJsonRequest<AircraftReportJson>(_ReportRowsAddress.Address);

            _BaseStationDatabase.Verify(db => db.GetCountOfFlightsForAircraft(It.IsAny<BaseStationAircraft>(), It.IsAny<SearchBaseStationCriteria>()), Times.Never());
            _BaseStationDatabase.Verify(db => db.GetCountOfFlights(It.IsAny<SearchBaseStationCriteria>()), Times.Never());

            Assert.AreEqual(0, json.CountRows);
            Assert.AreEqual(0, json.Flights.Count);
            Assert.AreEqual(0, json.Airports.Count);
            Assert.AreEqual(0, json.Routes.Count);
            Assert.IsTrue(json.Aircraft.IsUnknown);
        }

        
        [Test]
        public void Test_04_07_ValidateMixedRealityDataProviderName()
        {
            TestUtilities.InitializeMixedRealityToolkitScene(false);

            MixedRealityToolkit.TryRegisterService<ITestService>(new TestService1());
            var testService1 = MixedRealityToolkit.GetService<ITestService>();

            const string testName1 = "Test04-07-1";
            const string testName2 = "Test04-07-2";

            // Add test data providers
            MixedRealityToolkit.TryRegisterService<ITestDataProvider1>(new TestDataProvider1(testService1, testName1));
            MixedRealityToolkit.TryRegisterService<ITestDataProvider2>(new TestDataProvider2(testService1, testName2));

            // Retrieve
            var dataProvider1 = MixedRealityToolkit.GetService<ITestDataProvider1>(testName1);
            var dataProvider2 = MixedRealityToolkit.GetService<ITestDataProvider2>(testName2);

            // Tests
            Assert.AreEqual(testName1, dataProvider1.Name);
            Assert.AreEqual(testName2, dataProvider2.Name);
        }

        [Test]
        public void TestBasics() {
            var table = FbxBindingTable.Create(Manager, "table");

            // Call the getters, make sure they get.
            GetSetProperty(table.DescAbsoluteURL, "file:///dev/null");
            GetSetProperty(table.DescRelativeURL, "shader.glsl");
            GetSetProperty(table.DescTAG, "user");

            // Test dispose.
            var entry = table.AddNewEntry();
            DisposeTester.TestDispose(entry);

            // Test the views.
            entry = table.AddNewEntry();

            var propertyView = new FbxPropertyEntryView(entry, false);
            Assert.IsFalse(propertyView.IsValid());
            DisposeTester.TestDispose(propertyView);

            propertyView = new FbxPropertyEntryView(entry, true, true);
            Assert.IsTrue(propertyView.IsValid());
            Assert.AreEqual("FbxPropertyEntry", propertyView.EntryType());
            propertyView.SetProperty("property");
            Assert.AreEqual("property", propertyView.GetProperty());

            var semanticView = new FbxSemanticEntryView(entry, false);
            Assert.IsFalse(semanticView.IsValid());
            DisposeTester.TestDispose(semanticView);

            semanticView = new FbxSemanticEntryView(entry, false, true);
            Assert.IsTrue(semanticView.IsValid());
            Assert.AreEqual("FbxSemanticEntry", semanticView.EntryType());
            semanticView.SetSemantic("semantic");
            Assert.AreEqual("semantic", semanticView.GetSemantic());
            Assert.AreEqual(0, semanticView.GetIndex());
            Assert.AreEqual("semantic", semanticView.GetSemantic(false));
        }


[TestClass]
    public class IPAddressComparerTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Data Source='LibraryTests.xls';Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Extended Properties='Excel 8.0'",
                    "IPAddressComparer$")]
        public void Describe_Airport_Formats_Airport_Correctly()
        {
            var worksheet = new ExcelWorksheetData(TestContext);

            var comparer = new IPAddressComparer();
            var lhs = worksheet.String("LHS") == null ? null : IPAddress.Parse(worksheet.String("LHS"));
            var rhs = worksheet.String("RHS") == null ? null : IPAddress.Parse(worksheet.String("RHS"));
            var expectedResult = worksheet.Int("Result");

            var result = comparer.Compare(lhs, rhs);
            if(expectedResult < 0)      Assert.IsTrue(result < 0);
            else if(expectedResult > 0) Assert.IsTrue(result > 0);
            else                        Assert.AreEqual(0, result);
        }
    }

    
        [Test]
        public void DeleteOneControlPointWithCommandRedo()
        {
            AddControlPointCommand command = new AddControlPointCommand(this.LineSketchObject, new Vector3(1, 2, 3));
            Invoker.ExecuteCommand(command);

            DeleteControlPointCommand deleteCommand = new DeleteControlPointCommand(this.LineSketchObject);
            Invoker.ExecuteCommand(deleteCommand);
            Invoker.Undo();
            Invoker.Redo();

            Assert.AreEqual(this.LineSketchObject.getNumberOfControlPoints(), 0);
            Assert.IsTrue(SketchWorld.ActiveSketchWorld.IsObjectDeleted(this.LineSketchObject));
        }

        
      
        [Test]
        public void SaveOrientationWithTargetWithPivotDoCancelReset()
        {
            QuaternionEqualityComparer comparer = new QuaternionEqualityComparer(0.1f);
            DirectionModifierMock subjectMock = containingObject.AddComponent<DirectionModifierMock>();

            UnityEventListenerMock orientationResetCancelledMock = new UnityEventListenerMock();
            subjectMock.OrientationResetCancelled.AddListener(orientationResetCancelledMock.Listen);

            subjectMock.TargetInitialRotation = Quaternion.Euler(1f, 1f, 1f);
            subjectMock.PivotInitialRotation = Quaternion.Euler(1f, 1f, 1f);

            GameObject target = new GameObject("target");
            GameObject pivot = new GameObject("pivot");

            target.transform.eulerAngles = Vector3.one * 2f;
            pivot.transform.eulerAngles = Vector3.one * 2f;

            subjectMock.Target = target;
            subjectMock.Pivot = pivot;

            Assert.That(subjectMock.TargetInitialRotation, Is.EqualTo(Quaternion.Euler(1f, 1f, 1f)).Using(comparer));
            Assert.That(subjectMock.PivotInitialRotation, Is.EqualTo(Quaternion.Euler(1f, 1f, 1f)).Using(comparer));

            Assert.IsFalse(orientationResetCancelledMock.Received);

            subjectMock.SaveOrientation();

            Assert.That(subjectMock.TargetInitialRotation, Is.EqualTo(Quaternion.Euler(2f, 2f, 2f)).Using(comparer));
            Assert.That(subjectMock.PivotInitialRotation, Is.EqualTo(Quaternion.Euler(2f, 2f, 2f)).Using(comparer));
            Assert.IsTrue(orientationResetCancelledMock.Received);

            Object.DestroyImmediate(target);
            Object.DestroyImmediate(pivot);
        }
       
        
        [Test]
        public void ClearSourceInactiveComponent()
        {
            Assert.IsNull(subject.Source);
            VelocityTrackerMock tracker = VelocityTrackerMock.Generate(true, Vector3.one, Vector3.one);
            subject.Source = tracker;

            Assert.AreEqual(tracker, subject.Source);

            subject.enabled = false;
            subject.ClearSource();

            Assert.AreEqual(tracker, subject.Source);
            Object.DestroyImmediate(tracker.gameObject);
        }

        
        [Test]
        public void ClearContainingTransformValidityInactiveComponent()
        {
            GameObject containingObject = new GameObject("CollisionTrackerTest");
            CollisionTracker subject = containingObject.AddComponent<CollisionTracker>();

            Assert.IsNull(subject.ContainingTransformValidity);
            RuleContainer rule = new RuleContainer();
            subject.ContainingTransformValidity = rule;
            Assert.AreEqual(rule, subject.ContainingTransformValidity);
            subject.enabled = false;
            subject.ClearContainingTransformValidity();
            Assert.AreEqual(rule, subject.ContainingTransformValidity);

            Object.DestroyImmediate(containingObject);
        }

        
    [UnityTest]
    public IEnumerator MouseOutsideMaskRectTransform_WhileInsidePaddedArea_PerformsClick()
    {
        var mask = new GameObject("Panel").AddComponent<RectMask2D>();
        mask.gameObject.transform.SetParent(m_Canvas.transform);
        RectTransform panelRectTransform = mask.GetComponent<RectTransform>();
        panelRectTransform.sizeDelta = new Vector2(100, 100f);
        panelRectTransform.localPosition = Vector3.zero;

        m_Image.gameObject.transform.SetParent(mask.transform, true);
        mask.padding = new Vector4(-30, -30, -30, -30);


        PointerClickCallbackCheck callbackCheck = m_Image.gameObject.AddComponent<PointerClickCallbackCheck>();

        var canvasRT = m_Canvas.gameObject.transform as RectTransform;
        var screenMiddle = new Vector2(Screen.width / 2, Screen.height / 2);
        m_FakeBaseInput.MousePresent = true;
        m_FakeBaseInput.MousePosition = screenMiddle;

        yield return null;
        // Click the center of the screen should hit the middle of the image.
        m_FakeBaseInput.MouseButtonDown[0] = true;
        yield return null;
        m_FakeBaseInput.MouseButtonDown[0] = false;
        yield return null;
        m_FakeBaseInput.MouseButtonUp[0] = true;
        yield return null;
        m_FakeBaseInput.MouseButtonUp[0] = false;
        yield return null;
        Assert.IsTrue(callbackCheck.pointerDown);

        //Reset the callbackcheck and click outside the mask but still in the image.
        callbackCheck.pointerDown = false;
        m_FakeBaseInput.MousePosition = new Vector2(screenMiddle.x - 60, screenMiddle.y);
        yield return null;
        m_FakeBaseInput.MouseButtonDown[0] = true;
        yield return null;
        m_FakeBaseInput.MouseButtonDown[0] = false;
        yield return null;
        m_FakeBaseInput.MouseButtonUp[0] = true;
        yield return null;
        m_FakeBaseInput.MouseButtonUp[0] = false;
        yield return null;
        Assert.IsTrue(callbackCheck.pointerDown);

        //Reset the callbackcheck and click outside the mask and outside in the image.
        callbackCheck.pointerDown = false;
        m_FakeBaseInput.MousePosition = new Vector2(screenMiddle.x - 100, screenMiddle.y);
        yield return null;
        m_FakeBaseInput.MouseButtonDown[0] = true;
        yield return null;
        m_FakeBaseInput.MouseButtonDown[0] = false;
        yield return null;
        m_FakeBaseInput.MouseButtonUp[0] = true;
        yield return null;
        m_FakeBaseInput.MouseButtonUp[0] = false;
        yield return null;
        Assert.IsFalse(callbackCheck.pointerDown);
    }

        [Test]
        public void ExtractInactiveComponent()
        {
            UnityEventListenerMock sourceExtractedMock = new UnityEventListenerMock();
            UnityEventListenerMock targetExtractedMock = new UnityEventListenerMock();
            subject.SourceExtracted.AddListener(sourceExtractedMock.Listen);
            subject.TargetExtracted.AddListener(targetExtractedMock.Listen);

            TransformData sourceData = new TransformData();
            TransformData targetData = new TransformData();
            TransformPropertyApplier.EventData eventData = new TransformPropertyApplier.EventData();
            eventData.Set(sourceData, targetData);

            subject.enabled = false;

            Assert.IsFalse(sourceExtractedMock.Received);
            Assert.IsFalse(targetExtractedMock.Received);
            Assert.IsNull(subject.SourceResult);
            Assert.IsNull(subject.TargetResult);

            subject.Extract(eventData);

            Assert.IsFalse(sourceExtractedMock.Received);
            Assert.IsFalse(targetExtractedMock.Received);
            Assert.IsNull(subject.SourceResult);
            Assert.IsNull(subject.TargetResult);
        }
       
        
        [Test]
        public void PointerEnterAndRightClickShouldPress()
        {
            Assert.True(selectable.isStateNormal);
            selectable.InvokeOnPointerEnter(null);
            selectable.InvokeOnPointerDown(new PointerEventData(EventSystem.current));
            Assert.True(selectable.isStatePressed);
        }

        
        [Test]
        public void TestFitModeUnconstrained()
        {
            m_ContentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            m_ContentSizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;

            m_ContentSizeFitter.SetLayoutHorizontal();
            m_ContentSizeFitter.SetLayoutVertical();

            Assert.AreEqual(50, m_RectTransform.rect.width);
            Assert.AreEqual(50, m_RectTransform.rect.height);
        }


        
        [UnityTest]
        public IEnumerator AllSoundsShouldHaveAnAudioSource()
        {
            Sound[] s = am.GetSounds();
            yield return new WaitForSeconds(TestConstants.WAIT_TIME);
            Assert.NotNull(s);
            foreach (Sound sound in s)
            {
                if (sound.source == null || sound.source.clip == null)
                {
                    Assert.Fail(sound.name + " has a missing AudioSource or audio clip");
                }
            }
        }

       
        
        [Test]
        public void TransformExtractZ()
        {
            UnityEventListenerMock transformedListenerMock = new UnityEventListenerMock();
            subject.Transformed.AddListener(transformedListenerMock.Listen);
            subject.CoordinateToExtract = Vector3ToFloat.ExtractionCoordinate.ExtractZ;

            Assert.AreEqual(0f, subject.Result);
            Assert.IsFalse(transformedListenerMock.Received);

            Vector3 input = new Vector3(2f, 3f, 6f);
            float result = subject.Transform(input);
            float expectedResult = 6f;

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedResult, subject.Result);
            Assert.IsTrue(transformedListenerMock.Received);
        }

        
		[UnityTest]
		public IEnumerator ShouldStopMoving()
		{
			pc.StopMoving();
			yield return new WaitForSeconds(TestConstants.WAIT_TIME);
			Assert.AreEqual(0f, pc.GetSpeed());
			Assert.AreEqual(0f, pc.GetTurningSpeed());
		}


        
        [Test]
        public void TestBeginBadPolygonCreation()
        {
            // Add before begin. This crashes in native FBX SDK.
            using (FbxMesh mesh = CreateObject ("mesh")) {
                Assert.That(() => mesh.AddPolygon(0), Throws.Exception.TypeOf<FbxMesh.BadBracketingException>());
            }

            // End before begin. This is benign in native FBX SDK.
            using (FbxMesh mesh = CreateObject ("mesh")) {
                Assert.That(() => mesh.EndPolygon(), Throws.Exception.TypeOf<FbxMesh.BadBracketingException>());
            }

            // Begin during begin. This is benign in native FBX SDK.
            using (FbxMesh mesh = CreateObject ("mesh")) {
                mesh.BeginPolygon();
                Assert.That(() => mesh.BeginPolygon(), Throws.Exception.TypeOf<FbxMesh.BadBracketingException>());
            }

            // Negative polygon index. Benign in FBX SDK, but it will crash some importers.
            using (FbxMesh mesh = CreateObject ("mesh")) {
                mesh.BeginPolygon ();
                Assert.That(() => mesh.AddPolygon (-1), Throws.Exception.TypeOf<System.ArgumentOutOfRangeException>());
            }
        }
    
           [Test]
        public void Test_01_TestCodeGeneratedActions()
        {
            var pressAction = new MixedRealityInputAction(1, "Pressed", AxisType.Digital);
            var selectAction = new MixedRealityInputAction(2, "Select", AxisType.Digital);

            Assert.IsTrue(selectAction != pressAction);
            Assert.IsTrue(pressAction != MixedRealityInputAction.None);
            Assert.IsTrue(selectAction != MixedRealityInputAction.None);
        }

        
        [Test]
        public void FloatValueInactiveComponent()
        {
            subject.Timeline = animator;
            subject.ParameterName = "FloatTest";
            subject.enabled = false;
            Assert.AreEqual(0f, animator.GetFloat("FloatTest"));

            subject.FloatValue = 1f;

            Assert.AreEqual(0f, animator.GetFloat("FloatTest"));
            Assert.AreEqual(0f, subject.FloatValue);
        }

        
        
        [Test]
        public void SliceEmptyList()
        {
            UnityEventListenerMock slicedMock = new UnityEventListenerMock();
            subject.Sliced.AddListener(slicedMock.Listen);
            UnityEventListenerMock remainedMock = new UnityEventListenerMock();
            subject.Remained.AddListener(remainedMock.Listen);

            List<CollisionNotifier.EventData> collisionList = new List<CollisionNotifier.EventData>();
            ActiveCollisionsContainer.EventData eventData = new ActiveCollisionsContainer.EventData().Set(collisionList);

            subject.StartIndex = 0;
            subject.Length = 1;

            Assert.AreEqual("", ActiveCollisionsHelper.GetNamesOfActiveCollisions(eventData));

            Assert.IsFalse(slicedMock.Received);
            Assert.IsFalse(remainedMock.Received);

            ActiveCollisionsContainer.EventData remainedList;
            ActiveCollisionsContainer.EventData slicedList = subject.Slice(eventData, out remainedList);

            Assert.IsTrue(slicedMock.Received);
            Assert.IsTrue(remainedMock.Received);

            Assert.AreEqual("", ActiveCollisionsHelper.GetNamesOfActiveCollisions(slicedList));
            Assert.AreEqual("", ActiveCollisionsHelper.GetNamesOfActiveCollisions(remainedList));
        }

        
        [Test]
        public void SetNativeSizeSetsAllAsDirtyAndSetsAnchorMaxAndSizeDeltaWhenOverrideSpriteIsNotNull()
        {
            m_Image.sprite = m_Sprite;
            m_Image.overrideSprite = m_OverrideSprite;
            m_Image.rectTransform.anchorMax = new Vector2(100, 100);
            m_Image.rectTransform.anchorMin = new Vector2(0, 0);
            m_Image.SetNativeSize();
            Assert.True(m_dirtyVert, "Vertices have not been dirtied");
            Assert.True(m_dirtyLayout, "Layout has not been dirtied");
            Assert.True(m_dirtyMaterial, "Material has not been dirtied");
            Assert.AreEqual(m_Image.rectTransform.anchorMin, m_Image.rectTransform.anchorMax);
            Assert.AreEqual(m_OverrideSprite.rect.size / m_Image.pixelsPerUnit, m_Image.rectTransform.sizeDelta);
        }
}
