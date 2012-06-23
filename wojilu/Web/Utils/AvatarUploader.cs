/*
 * Copyright 2010 www.wojilu.com
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System;
using System.IO;
using System.Web;
using System.Drawing;
using wojilu.Drawing;

namespace wojilu.Web.Utils {

    /// <summary>
    /// 头像上传工具
    /// </summary>
    public class AvatarUploader {

        private static readonly ILog logger = LogManager.GetLogger( typeof( AvatarUploader ) );

        /// <summary>
        /// 保存用户上传的头像
        /// </summary>
        /// <param name="postedFile"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Result Save( HttpFile postedFile, int userId ) {
            return upload_private( sys.Path.DiskAvatar, postedFile, userId );
        }


        public static void Delete( String picPath ) {

            String fullPath = strUtil.Join( "/static/upload/", picPath );
            Boolean deleted = deleteImgPrivate( fullPath, "small" );

            String oPath = Img.GetOriginalPath( fullPath );
            deleteImgPrivate( oPath, "original" );

            if (config.Instance.Site.IsSaveAvatarMedium) {
                String mPath = Img.GetThumbPath( fullPath, ThumbnailType.Medium );
                deleteImgPrivate( mPath, "medium" );
            }

            if (config.Instance.Site.IsSaveAvatarBig) {
                String bPath = Img.GetThumbPath( fullPath, ThumbnailType.Big );
                deleteImgPrivate( bPath, "big" );
            }
        }

        private static Boolean deleteImgPrivate( String fullPath, String dtype ) {
            String absPath = PathHelper.Map( fullPath );
            if (file.Exists( absPath )) {
                file.Delete( absPath );
                logger.Info( "删除头像成功" + dtype + ":" + absPath );
                return true;
            }
            else {
                logger.Error( "头像不存在" + dtype + ":" + absPath );
                return false;
            }
        }


        public static Result Save( String oPicAbsPath, int userId ) {

            Result result = new Result();

            if (file.Exists( oPicAbsPath ) == false) {
                String msg = "图片不存在" + oPicAbsPath;
                logger.Error( msg );
                result.Add( msg );
                return result;
            }

            String uploadPath = sys.Path.DiskAvatar;

            AvatarSaver aSaver = AvatarSaver.New( oPicAbsPath );

            return savePicCommon( aSaver, userId, result, uploadPath );

        }

        private static Result savePicCommon( AvatarSaver aSaver, int userId, Result result, String uploadPath ) {

            DateTime now = DateTime.Now;
            String strDir = getDirName( now );
            String fullDir = strUtil.Join( uploadPath, strDir );

            String absPath = PathHelper.Map( fullDir );
            if (!Directory.Exists( absPath )) {
                Directory.CreateDirectory( absPath );
                logger.Info( "CreateDirectory:" + absPath );
            }

            String picName = string.Format( "{0}_{1}_{2}_{3}", userId, now.Hour, now.Minute, now.Second );
            String picNameWithExt = strUtil.Join( picName, aSaver.GetExt(), "." );

            String picAbsPath = Path.Combine( absPath, picNameWithExt );
            try {

                aSaver.Save( picAbsPath );
                saveAvatarThumb( picAbsPath );
            }
            catch (Exception exception) {
                logger.Error( lang.get( "exPhotoUploadError" ) + ":" + exception.Message );
                result.Add( lang.get( "exPhotoUploadErrorTip" ) );
                return result;
            }

            // 返回的信息是缩略图
            String relPath = strUtil.Join( fullDir, picNameWithExt ).TrimStart( '/' );
            relPath = strUtil.TrimStart( relPath, "static/upload/" );
            String thumbPath = Img.GetThumbPath( relPath );

            logger.Info( "return thumbPath=" + thumbPath );

            result.Info = thumbPath;
            return result;
        }

        private static Result upload_private( String uploadPath, HttpFile postedFile, int userId ) {

            logger.Info( "uploadPath:" + uploadPath + ", userId:" + userId );

            Result result = new Result();

            Uploader.checkUploadPic( postedFile, result );
            if (result.HasErrors) return result;

            AvatarSaver aSaver = AvatarSaver.New( postedFile );

            return savePicCommon( aSaver, userId, result, uploadPath );


            //DateTime now = DateTime.Now;
            //String strDir = getDirName( now );
            //String fullDir = strUtil.Join( uploadPath, strDir );

            //String absPath = PathHelper.Map( fullDir );
            //if (!Directory.Exists( absPath )) {
            //    Directory.CreateDirectory( absPath );
            //    logger.Info( "CreateDirectory:" + absPath );
            //}

            //String picName = string.Format( "{0}_{1}_{2}_{3}", userId, now.Hour, now.Minute, now.Second );
            //String picNameWithExt = picName + "." + Img.GetImageExt( postedFile.ContentType );

            //String picAbsPath = Path.Combine( absPath, picNameWithExt );
            //try {
            //    postedFile.SaveAs( picAbsPath );
            //    saveAvatarThumb( picAbsPath );
            //}
            //catch (Exception exception) {
            //    logger.Error( lang.get( "exPhotoUploadError" ) + ":" + exception.Message );
            //    result.Add( lang.get( "exPhotoUploadErrorTip" ) );
            //    return result;
            //}

            //// 返回的信息是缩略图
            //String relPath = strUtil.Join( fullDir, picNameWithExt ).TrimStart( '/' );
            //relPath = strUtil.TrimStart( relPath, "static/upload/" );
            //String thumbPath = Img.GetThumbPath( relPath );

            //logger.Info( "return thumbPath=" + thumbPath );

            //result.Info = thumbPath;
            //return result;

        }


        private static string getDirName( DateTime now ) {
            return string.Format( "{0}/{1}/{2}", now.Year, now.Month, now.Day );
        }


        private static void saveAvatarThumb( String srcPath ) {

            Boolean saveSmallThumb = true;
            if (saveSmallThumb) {
                int x = config.Instance.Site.AvatarThumbWidth;
                int y = config.Instance.Site.AvatarThumbHeight;
                saveAvatarPrivate( x, y, srcPath, ThumbnailType.Small );
            }

            if (config.Instance.Site.IsSaveAvatarMedium) {
                int x = config.Instance.Site.AvatarThumbWidthMedium;
                int y = config.Instance.Site.AvatarThumbHeightMedium;
                saveAvatarPrivate( x, y, srcPath, ThumbnailType.Medium );
            }

            if (config.Instance.Site.IsSaveAvatarBig) {
                int x = config.Instance.Site.AvatarThumbWidthBig;
                int y = config.Instance.Site.AvatarThumbHeightBig;
                saveAvatarPrivate( x, y, srcPath, ThumbnailType.Big );
            }

        }

        private static void saveAvatarPrivate( int x, int y, String srcPath, ThumbnailType ttype ) {

            String thumbPath = Img.GetThumbPath( srcPath, ttype );

            using (Image img = Image.FromFile( srcPath )) {
                if (img.Size.Width <= x && img.Size.Height <= y) {
                    File.Copy( srcPath, thumbPath );
                }
                else {
                    logger.Info( "SaveThumbnail..." + ttype.ToString() );
                    Img.SaveThumbnail( srcPath, thumbPath, x, y, SaveThumbnailMode.Cut );
                }
            }


        }

    }
}

