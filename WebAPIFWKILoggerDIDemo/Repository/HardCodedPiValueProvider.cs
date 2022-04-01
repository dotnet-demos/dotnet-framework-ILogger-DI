namespace WebAPIFWKILoggerDIDemo
{
    class HardCodedPiValueProvider : IPiValueProvider
    {
        double IPiValueProvider.Get()
        {
            return 3.14;
        }
    }
}
