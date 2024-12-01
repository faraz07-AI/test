using Zinnia.Data.Type;
using Zinnia.Tracking.Modification;
using Zinnia.Tracking.Modification.Operation.Extraction;

namespace Test.Zinnia.Tracking.Modification.Operation.Extraction
{
    using NUnit.Framework;
    using Test.Zinnia.Utility.Mock;
    using UnityEngine;

    public class TransformPropertyApplierEventDataExtractorTest
    {
        private GameObject containingObject;
        private TransformPropertyApplierEventDataExtractor subject;

        // [SetUp]
        // public void SetUp()
        // {
        //     containingObject = new GameObject("TransformPropertyApplierEventDataExtractorTest");
        //     subject = containingObject.AddComponent<TransformPropertyApplierEventDataExtractor>();
        // }

        [SetUp]
        public void Init ()
        {
            m_fbxManager = FbxManager.Create ();
            m_fbxMesh = FbxMesh.Create (m_fbxManager, "");
            m_fbxLayer = m_fbxMesh.GetLayer (0);
            if (m_fbxLayer == null)
            {
                m_fbxMesh.CreateLayer ();
                m_fbxLayer = m_fbxMesh.GetLayer (0 /* default layer */);
            }
        }

        [Test]
        public void TestEquality() {
            var aIndex = m_fbxMesh.CreateLayer();
            var bIndex = m_fbxMesh.CreateLayer();
            var a = m_fbxMesh.GetLayer(aIndex);
            var b = m_fbxMesh.GetLayer(bIndex);
            var acopy = m_fbxMesh.GetLayer(aIndex);
            EqualityTester<FbxLayer>.TestEquality(a, b, acopy);
        }

        // [Test]
        // public void ExtractInactiveComponent()
        // {
        //     UnityEventListenerMock sourceExtractedMock = new UnityEventListenerMock();
        //     UnityEventListenerMock targetExtractedMock = new UnityEventListenerMock();
        //     subject.SourceExtracted.AddListener(sourceExtractedMock.Listen);
        //     subject.TargetExtracted.AddListener(targetExtractedMock.Listen);

        //     TransformData sourceData = new TransformData();
        //     TransformData targetData = new TransformData();
        //     TransformPropertyApplier.EventData eventData = new TransformPropertyApplier.EventData();
        //     eventData.Set(sourceData, targetData);

        //     subject.enabled = false;

        //     Assert.IsFalse(sourceExtractedMock.Received);
        //     Assert.IsFalse(targetExtractedMock.Received);
        //     Assert.IsNull(subject.SourceResult);
        //     Assert.IsNull(subject.TargetResult);

        //     subject.Extract(eventData);

        //     Assert.IsFalse(sourceExtractedMock.Received);
        //     Assert.IsFalse(targetExtractedMock.Received);
        //     Assert.IsNull(subject.SourceResult);
        //     Assert.IsNull(subject.TargetResult);
        // }
   }
}
        
