namespace ATXLoader
{
    // 환경 변수
    public class IP
    {
        public IP()
        {
            ext_prec = false;
        }

        // 좌표 자리수(true : 15+2, false : 6+2)
        public bool ext_prec { get; set; }
    }
}
