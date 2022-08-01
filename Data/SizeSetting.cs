namespace Data.SizeSetting{
    class Size
    {
        public double HW {get; set;}
        public int DpiName {get; set;}
        public string Platform {get; set;}
        public string Role {get; set;}
        public string Subtype {get; set;}
        public Size(double s, int scale, string ideom, string r = "", string subt = "")
        {    
            HW = s;
            DpiName = scale;
            Platform = ideom;
            Role = r;
            Subtype = subt;
        }
    }
    class OutputSettings
    {
        public List<Size> iphoneSizes = new List<Size>()
        {
            new Size(60, 3, "iphone"),
            new Size(40, 2, "iphone"),
            new Size(40, 3, "iphone"),
            new Size(60, 2, "iphone"),
            new Size(57, 1, "iphone"),
            new Size(29, 2, "iphone"),
            new Size(29, 3, "iphone"),
            new Size(57, 2, "iphone"),
            new Size(20, 2, "iphone"),
            new Size(20, 3, "iphone"),
        };

        public List<Size> ipadSizes = new List<Size>()
        {
            new Size(40, 2, "ipad"),
            new Size(72, 1, "ipad"),
            new Size(50, 2, "ipad"),
            new Size(29, 2, "ipad"),
            new Size(76, 1, "ipad"),
            new Size(29, 1, "ipad"),
            new Size(50, 1, "ipad"),
            new Size(72, 2, "ipad"),
            new Size(40, 1, "ipad"),
            new Size(83.5, 2, "ipad"),
            new Size(20, 1, "ipad"),
            new Size(20, 2, "ipad"),
        };

        public List<Size> watchSizes = new List<Size>()
        {
            new Size(86, 2, "watch", "quickLook", "38mm"),
            new Size(40, 2, "watch", "appLauncher", "38mm"),
            new Size(44, 2, "watch", "appLauncher", "40mm"),
            new Size(50, 2, "watch", "appLauncher", "44mm"),
            new Size(98, 2, "watch", "quickLook", "42mm"),
            new Size(108, 2, "watch", "quickLook", "44mm"),
            new Size(24, 2, "watch", "notificationCenter", "38mm"),
            new Size(27.5, 2, "watch", "quickLook", "42mm"),
            new Size(29, 3, "watch", "companionSettings"),
            new Size(29, 2, "watch", "companionSettings"),
            new Size(1024, 1, "watch-marketing"),
        };

        public List<Size> macSizes = new List<Size>()
        {
            new Size(128, 1, "mac"),
            new Size(256, 1, "mac"),
            new Size(128, 2, "mac"),
            new Size(256, 2, "mac"),
            new Size(32, 1, "mac"),
            new Size(512, 1, "mac"),
            new Size(16, 1, "mac"),
            new Size(16, 2, "mac"),
            new Size(32, 2, "mac"),
            new Size(512, 2, "mac"),
        };

        public List<Size> androidSizes = new List<Size>()
        {
            new Size(48, 1, "android"),
            new Size(72, 1, "android"),
            new Size(96, 1, "android"),
            new Size(144, 1, "android"),
            new Size(192, 1, "android"),
        };

        public List<Size> mainSizes = new List<Size>()
        {
            new Size(1024, 1, "ios-marketing"),
            new Size(512, 1, "android-marketing"),
        };

    }
}