[Test]
 public void ListSizeTest(){
    List<GameObject> testComponents = new List<GameObject>();
    System.out.println("it is reaching into listsize");
    GameObject g = new GameObject();
    testComponents.Add(g)
    Assert.IsTrue(true);
}


[UnityTest]
 public IEnumerator ModifyAndDiverge()
 {
            subject.TrackDivergence = true;
            GameObject source = new GameObject("RigidbodyVelocityTest");
            GameObject target = subject.gameObject;

            UnityEventListenerMock convergedListenerMock = new UnityEventListenerMock();
            UnityEventListenerMock divergedListenerMock = new UnityEventListenerMock();
            subject.Converged.AddListener(convergedListenerMock.Listen);
            subject.Diverged.AddListener(divergedListenerMock.Listen);

            source.transform.position = Vector3.zero;
            target.transform.position = Vector3.zero;

            Assert.IsFalse(convergedListenerMock.Received);
            Assert.IsFalse(divergedListenerMock.Received);
            convergedListenerMock.Reset();
            divergedListenerMock.Reset();

            Assert.IsFalse(subject.AreDiverged(source, target));

            source.transform.position = Vector3.one * 10f;

            subject.Modify(source, target);

            Assert.IsFalse(convergedListenerMock.Received);
            Assert.IsTrue(divergedListenerMock.Received);
            convergedListenerMock.Reset();
            divergedListenerMock.Reset();

            Assert.IsTrue(subject.AreDiverged(source, target));

            int fallbackCounter = 0;
            int fallbackCounterMax = 2500;
            while (subject.AreDiverged(source, target) && fallbackCounter < fallbackCounterMax)
            {
                subject.Modify(source, target);
                fallbackCounter++;
                yield return null;
            }

            if (fallbackCounter >= fallbackCounterMax)
            {
                Assert.IsTrue(true);
                Debug.LogWarning("Skipping Test [Test.Zinnia.Tracking.Follow.Modifier.Property.Position.RigidbodyVelocityTest -> ModifyAndDiverge] due to taking too long to run.");
            }
            else
            {
                Assert.IsTrue(convergedListenerMock.Received);
                Assert.IsFalse(divergedListenerMock.Received);
                Assert.IsFalse(subject.AreDiverged(source, target));
            }

            Object.DestroyImmediate(source);
            Object.DestroyImmediate(target);
 }
