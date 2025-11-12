namespace TestManagment.Domain.ValueObjects.Test
{
    public class TestPublicationStatus
    {
        public bool IsPublished { get; } = false;
        public TestPublicationStatus()
        {
            IsPublished = false;
        }
        public TestPublicationStatus(bool isPublish)
        {
            this.IsPublished = isPublish;
        }

        public TestPublicationStatus Publish() 
        {
            return new TestPublicationStatus(true);
        }
        public TestPublicationStatus unPublish()
        {
            return new TestPublicationStatus(false);
        }

        public static implicit operator bool(TestPublicationStatus self) => self.IsPublished;
    }
}
