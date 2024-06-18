namespace KTNEManual.DomainTest._Util
{
    public static class AssertExtension
    {
        public static void WithMessage(this Exception exception, string message)
        {
            if (exception.Message == message)
                Assert.True(true);
            else
                Assert.False(false, $"Waited message '{message}'");
        }
    }
}
