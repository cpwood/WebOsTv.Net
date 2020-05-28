namespace WebOsTv.Net.Responses.Tv
{
    public class ThreeDimensionStatusResponse : ResponseBase
    {
        public Status3d Status3D { get; set; }

        public class Status3d
        {
            public bool Status { get; set; }
            public string Pattern { get; set; }
        }

    }
}
