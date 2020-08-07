using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingCaptcha
{
    /* ======================
	* 功能描述：添加描述信息
	* 创 建 者：Administrator
	* 创建日期：2018/8/16 17:50:02
	* 修    改：
	* ========================*/
    public class CaptchaHelper
    {


        public int OffSetX { get; set; }
        public int OffSetY { get; set; }

        public int VOffSet { get; set; }

        private static Lazy<CaptchaHelper> _default = new Lazy<CaptchaHelper>(() => new CaptchaHelper() { });

        public static CaptchaHelper Default
        {
            get
            {
                return _default.Value;
            }
        }


        static CaptchaHelper()
        {

        }


        /// <summary>
        /// 根据原图片 处理新图片
        /// </summary>
        /// <param name="SourcePicPath"></param>
        /// <returns></returns>
        public ImageInfo GetInitImage(int width = 400, int height = 200, string picInit = "", int vOffset=5)
        {
            VOffSet = vOffset;
            var sourcePicPath = ImageHelper.Default.GetRandImagePath(picInit);
            string newfilepath = sourcePicPath;
            //缩放图片
            //ImageHelper.Default.GetThumbnail(sourcePicPath,newfilepath, width, height);
            int offsetX = 0;
            int offsetY = 0;
            int cutwidth = 0;
            int cutheight = 0;

            string cutpic = picInit + "\\cutpic\\" + DateTime.Now.ToString("yyyyMMdd") + "\\cut_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(newfilepath);
            string newpic = picInit + "\\cutpic\\" + DateTime.Now.ToString("yyyyMMdd") + "\\new_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(newfilepath);
            bool cutResult = ImageHelper.Default.CaptureImage(newfilepath, cutpic, newpic, out offsetX, out offsetY, out cutwidth, out cutheight);
            if (cutResult)
            {
                OffSetX = offsetX;
                OffSetY = offsetY;
            }
            string newpicpath = "/upload" + newpic.Replace(picInit, "").Replace("\\", "/");
            string cutpicpath = "/upload" + cutpic.Replace(picInit, "").Replace("\\", "/");
            string sourcepicpath = newpicpath;
            return new ImageInfo { SourcePicPath = sourcepicpath, NewPicPath = newpicpath, SmallPicPath = cutpicpath, CutHeight = cutheight, CutWidth = cutwidth, OffSetX = offsetX, OffSetY = offsetY };
        }

        /// <summary>
        /// 验证图片块移动的最终位置坐标
        /// </summary>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <returns></returns>
        public bool ValidateCaptcha(int offsetX, int voffset=2)
        {
            if (Math.Abs(offsetX - OffSetX) <= voffset)
            {
                return true;
            }
            return false;
        }
    }
}
