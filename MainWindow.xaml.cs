using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Permissions;

namespace TestRestLibrary
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        CookieContainer cookies = new CookieContainer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.globalInfo_textBox_url.Text = Properties.Settings.Default.global_url;

            this.login_textBox_userName.Text = Properties.Settings.Default.login_userName;
            this.login_passwordBox.Password = Properties.Settings.Default.login_password;
            this.login_textBox_parameters.Text = Properties.Settings.Default.login_parameters;

            this.writeRes_textBox_resPath.Text = Properties.Settings.Default.writeRes_respath;
            this.writeRes_textBox_content.Text = Properties.Settings.Default.writeRes_content;
            this.writeRes_textBox_inputTimestamp.Text = Properties.Settings.Default.writeRes_inputTimestamp;
            this.writeRes_textBox_metadata.Text = Properties.Settings.Default.writeRes_metadata;
            this.writeRes_textBox_ranges.Text = Properties.Settings.Default.writeRes_ranges;
            this.writeRes_textBox_style.Text = Properties.Settings.Default.writeRes_style;
            this.writeRes_textBox_totalLength.Text = Properties.Settings.Default.writeRes_totalLength;

            this.getReaderInfo_textBox_barcode.Text = Properties.Settings.Default.getReaderInfo_barcode;
            this.getReaderInfo_textBox_resultTypeList.Text = Properties.Settings.Default.getReaderInfo_resultTypeList;

            this.setReaderInfo_textBox_action.Text = Properties.Settings.Default.setReaderInfo_action;
            this.setReaderInfo_textBox_recPath.Text = Properties.Settings.Default.setReaderInfo_resPath;
            this.setReaderInfo_textBox_newXml.Text = Properties.Settings.Default.setReaderInfo_newXml;
            this.setReaderInfo_textBox_oldXml.Text = Properties.Settings.Default.setReaderInfo_oldXml;
            this.setReaderInfo_textBox_oldTimestamp.Text = Properties.Settings.Default.setReaderInfo_oldTimestamp;

            this.setLang_textBox_lang.Text = Properties.Settings.Default.setLang_lang;

            this.verifyReaderPassword_textBox_readerBarcode.Text = Properties.Settings.Default.verifyReaderPassword_readerBarcode;
            this.verifyReaderPassword_passwordBox.Password = Properties.Settings.Default.verifyReaderPassword_password;

            this.changeReaderPassword_textBox_readerBarcode.Text = Properties.Settings.Default.changeReaderPassword_readerBarcode;
            this.changeReaderPassword_passwordBox_old.Password = Properties.Settings.Default.changeReaderPassword_password_old;
            this.changeReaderPassword_passwordBox_new.Password = Properties.Settings.Default.changeReaderPassword_password_new;

            this.SearchBiblio_textBox_nPerMax.Text = Properties.Settings.Default.searchBiblio_perMax;
            this.SearchBiblio_comboBox_strBiblioDbNames.Text = Properties.Settings.Default.searchBiblio_biblioDbNames;
            this.SearchBiblio_comboBox_strFromStyle.Text = Properties.Settings.Default.searchBiblio_fromStyle;
            this.SearchBiblio_comboBox_strMatchStyle.Text = Properties.Settings.Default.searchBiblio_matchStyle;
            this.SearchBiblio_textBox_strLang.Text = Properties.Settings.Default.searchBiblio_lang;
            this.SearchBiblio_textBox_strOutputStyle.Text = Properties.Settings.Default.searchBiblio_outputStyle;
            this.SearchBiblio_textBox_strResultSetName.Text = Properties.Settings.Default.searchBiblio_resultSetName;
            this.SearchBiblio_textBox_strSearchStyle.Text = Properties.Settings.Default.searchBiblio_searchStyle;
            this.SearchBiblio_textBox_strQueryWord.Text = Properties.Settings.Default.searchBiblio_queryWord;

            this.getSearchResult_textBox_Count.Text = Properties.Settings.Default.getSearchResult_count;
            this.getSearchResult_textBox_resultsetName.Text = Properties.Settings.Default.getSearchResult_resultsetName;
            this.getSearchResult_textBox_strBrowseInfoStyle.Text = Properties.Settings.Default.getSearchResult_browseInfoStyle;
            this.getSearchResult_textBox_strLang.Text = Properties.Settings.Default.getSearchResult_lang;
            this.getSearchResult_textBox_start.Text = Properties.Settings.Default.getSearchResult_start;

            this.SearchReader_comboBox_strFrom.Text = Properties.Settings.Default.searchReader_from;
            this.SearchReader_comboBox_strMatchStyle.Text = Properties.Settings.Default.searchReader_matchStyle;
            this.SearchReader_comboBox_strReaderDbNames.Text = Properties.Settings.Default.searchReader_readerDbNames;
            this.SearchReader_textBox_nPerMax.Text = Properties.Settings.Default.searchReader_perMax;
            this.SearchReader_textBox_strLang.Text = Properties.Settings.Default.searchReader_lang;
            this.SearchReader_textBox_strOutputStyle.Text = Properties.Settings.Default.searchReader_outputStyle;
            this.SearchReader_textBox_strQueryWord.Text = Properties.Settings.Default.searchReader_queryWord;
            this.SearchReader_textBox_strResultSetName.Text = Properties.Settings.Default.searchReader_resultSetName;

            this.GetBiblioInfo_textBox_strBiblioRecPath.Text = Properties.Settings.Default.getBiblioInfo_biblioRecPath;
            this.GetBiblioInfo_comboBox_strBiblioType.Text = Properties.Settings.Default.getBiblioInfo_biblioType;

            this.GetItemInfo_comboBox_strResultType.Text = Properties.Settings.Default.getItemInfo_resultType;
            this.GetItemInfo_comboBox_strBiblioType.Text = Properties.Settings.Default.getItemInfo_biblioType;
            this.GetItemInfo_textBox_strBarcode.Text = Properties.Settings.Default.getItemInfo_barcode;

            this.GetEntities_textBox_strBiblioRecPath.Text = Properties.Settings.Default.getEntities_biblioRecPath;
            this.GetEntities_textBox_strLang.Text = Properties.Settings.Default.getEntities_lang;
            this.GetEntities_textBox_lCount.Text = Properties.Settings.Default.getEntities_count;
            this.GetEntities_textBox_lStart.Text = Properties.Settings.Default.getEntities_start;
            this.GetEntities_comboBox_strStyle.Text = Properties.Settings.Default.getEntities_style;

            this.GetBiblioSummary_textBox_strItemBarcode.Text = Properties.Settings.Default.getBiblioSummary_itemBarcode;
            this.GetBiblioSummary_textBox_strConfirmItemRecPath.Text = Properties.Settings.Default.getBiblioSummary_confirmItemRecPath;
            this.GetBiblioSummary_textBox_strBiblioRecPathExclude.Text = Properties.Settings.Default.getBiblioSummary_biblioRecPathExclude;

            this.GetOperLog_textbox_lHint.Text = Properties.Settings.Default.getOperLog_hint;
            this.GetOperLog_textbox_lIndex.Text = Properties.Settings.Default.getOperLog_index;
            this.GetOperLog_textbox_strFileName.Text = Properties.Settings.Default.getOperLog_fileName;
            this.GetOperLog_textbox_nAttachmentFragmentLength.Text = Properties.Settings.Default.getOperLog_attachmentFragmentLength;
            this.GetOperLog_textbox_lAttachmentFragmentStart.Text = Properties.Settings.Default.getOperLog_attachmentFragmentStart;

            this.GetBrowseRecords_textbox_paths.Text = Properties.Settings.Default.getBrowseRecords_paths;
            this.GetBrowseRecords_textbox_strBrowseInfoStyle.Text = Properties.Settings.Default.getBrowseRecords_browseInfoStyle;

            this.Return_comboBox_strAction.Text = Properties.Settings.Default.return_action;
            this.Return_textBox_strBiblioFormatList.Text = Properties.Settings.Default.return_biblioFormatList;
            this.Return_textBox_strComfirmItemRecPath.Text = Properties.Settings.Default.getBiblioSummary_confirmItemRecPath;
            this.Return_textBox_strItemBarcode.Text = Properties.Settings.Default.return_itemBarcode;
            this.Return_textBox_strItemFormatList.Text = Properties.Settings.Default.return_itemFormatList;
            this.Return_textBox_strReaderBarcode.Text = Properties.Settings.Default.return_readerBarcode;
            this.Return_textBox_strReaderFormatList.Text = Properties.Settings.Default.return_readerFormatList;
            this.Return_textBox_strStyle.Text = Properties.Settings.Default.return_style;

            this.PassGate_textBox_strReaderBarcode.Text = Properties.Settings.Default.passGate_readerBarcode;
            this.PassGate_textBox_strResultTypeList.Text = Properties.Settings.Default.passGate_resultTypeList;
            this.PassGate_textBox_strGateName.Text = Properties.Settings.Default.passGate_gateName;

            this.GetStatisInfo_textBox_strDateRangeString.Text = Properties.Settings.Default.getStatisInfo_dateRangeString;

            this.GetAuthorNumber_textBox_strAuthor.Text = Properties.Settings.Default.getAuthorNumber_strAuthor;
            this.GetAuthorNumber_checkBox_bSelectPinyin.IsChecked = Properties.Settings.Default.getAuthorNumber_bSelectPinyin;
            this.GetAuthorNumber_checkBox_bSelectEntry.IsChecked = Properties.Settings.Default.getAuthorNumber_bSelectEntry;
            this.GetAuthorNumber_checkBox_bOutputDebugInfo.IsChecked = Properties.Settings.Default.getAuthorNumber_bOutputDebugInfo;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.global_url = this.globalInfo_textBox_url.Text;

            Properties.Settings.Default.login_userName = this.login_textBox_userName.Text;
            Properties.Settings.Default.login_password = this.login_passwordBox.Password;
            Properties.Settings.Default.login_parameters = this.login_textBox_parameters.Text;


            Properties.Settings.Default.writeRes_respath = this.writeRes_textBox_resPath.Text;

            Properties.Settings.Default.getReaderInfo_barcode = this.getReaderInfo_textBox_barcode.Text;
            Properties.Settings.Default.getReaderInfo_resultTypeList = this.getReaderInfo_textBox_resultTypeList.Text;

            Properties.Settings.Default.setReaderInfo_action = this.setReaderInfo_textBox_action.Text;
            Properties.Settings.Default.setReaderInfo_resPath = this.setReaderInfo_textBox_recPath.Text;
            Properties.Settings.Default.setReaderInfo_newXml = this.setReaderInfo_textBox_newXml.Text;
            Properties.Settings.Default.setReaderInfo_oldXml = this.setReaderInfo_textBox_oldXml.Text;
            Properties.Settings.Default.setReaderInfo_oldTimestamp = this.setReaderInfo_textBox_oldTimestamp.Text;

            Properties.Settings.Default.verifyReaderPassword_readerBarcode = this.verifyReaderPassword_textBox_readerBarcode.Text;
            Properties.Settings.Default.verifyReaderPassword_password = this.verifyReaderPassword_passwordBox.Password;

            Properties.Settings.Default.changeReaderPassword_readerBarcode = this.changeReaderPassword_textBox_readerBarcode.Text;
            Properties.Settings.Default.changeReaderPassword_password_old = this.changeReaderPassword_passwordBox_old.Password;
            Properties.Settings.Default.changeReaderPassword_password_new = this.changeReaderPassword_passwordBox_new.Password;

            Properties.Settings.Default.searchBiblio_perMax = this.SearchBiblio_textBox_nPerMax.Text;
            Properties.Settings.Default.searchBiblio_biblioDbNames = this.SearchBiblio_comboBox_strBiblioDbNames.Text;
            Properties.Settings.Default.searchBiblio_fromStyle = this.SearchBiblio_comboBox_strFromStyle.Text;
            Properties.Settings.Default.searchBiblio_matchStyle = this.SearchBiblio_comboBox_strMatchStyle.Text;
            Properties.Settings.Default.searchBiblio_lang = this.SearchBiblio_textBox_strLang.Text;
            Properties.Settings.Default.searchBiblio_outputStyle = this.SearchBiblio_textBox_strOutputStyle.Text;
            Properties.Settings.Default.searchBiblio_resultSetName = this.SearchBiblio_textBox_strResultSetName.Text;
            Properties.Settings.Default.searchBiblio_searchStyle = this.SearchBiblio_textBox_strSearchStyle.Text;
            Properties.Settings.Default.searchBiblio_queryWord = this.SearchBiblio_textBox_strQueryWord.Text;

            Properties.Settings.Default.getSearchResult_count = this.getSearchResult_textBox_Count.Text;
            Properties.Settings.Default.getSearchResult_resultsetName = this.getSearchResult_textBox_resultsetName.Text;
            Properties.Settings.Default.getSearchResult_browseInfoStyle = this.getSearchResult_textBox_strBrowseInfoStyle.Text;
            Properties.Settings.Default.getSearchResult_lang = this.getSearchResult_textBox_strLang.Text;
            Properties.Settings.Default.getSearchResult_start = this.getSearchResult_textBox_start.Text;

            Properties.Settings.Default.searchReader_from = this.SearchReader_comboBox_strFrom.Text;
            Properties.Settings.Default.searchReader_matchStyle = this.SearchReader_comboBox_strMatchStyle.Text;
            Properties.Settings.Default.searchReader_readerDbNames = this.SearchReader_comboBox_strReaderDbNames.Text;
            Properties.Settings.Default.searchReader_perMax = this.SearchReader_textBox_nPerMax.Text;
            Properties.Settings.Default.searchReader_lang = this.SearchReader_textBox_strLang.Text;
            Properties.Settings.Default.searchReader_outputStyle = this.SearchReader_textBox_strOutputStyle.Text;
            Properties.Settings.Default.searchReader_queryWord = this.SearchReader_textBox_strQueryWord.Text;
            Properties.Settings.Default.searchReader_resultSetName = this.SearchReader_textBox_strResultSetName.Text;

            Properties.Settings.Default.getBiblioInfo_biblioRecPath = this.GetBiblioInfo_textBox_strBiblioRecPath.Text;
            Properties.Settings.Default.getBiblioInfo_biblioType = this.GetBiblioInfo_comboBox_strBiblioType.Text;

            Properties.Settings.Default.getItemInfo_resultType = this.GetItemInfo_comboBox_strResultType.Text;
            Properties.Settings.Default.getItemInfo_biblioType = this.GetItemInfo_comboBox_strBiblioType.Text;
            Properties.Settings.Default.getItemInfo_barcode = this.GetItemInfo_textBox_strBarcode.Text;

            Properties.Settings.Default.getEntities_biblioRecPath = this.GetEntities_textBox_strBiblioRecPath.Text;
            Properties.Settings.Default.getEntities_lang = this.GetEntities_textBox_strLang.Text;
            Properties.Settings.Default.getEntities_count = this.GetEntities_textBox_lCount.Text;
            Properties.Settings.Default.getEntities_start = this.GetEntities_textBox_lStart.Text;
            Properties.Settings.Default.getEntities_style = this.GetEntities_comboBox_strStyle.Text;

            Properties.Settings.Default.getBiblioSummary_itemBarcode = this.GetBiblioSummary_textBox_strItemBarcode.Text;
            Properties.Settings.Default.getBiblioSummary_confirmItemRecPath = this.GetBiblioSummary_textBox_strConfirmItemRecPath.Text;
            Properties.Settings.Default.getBiblioSummary_biblioRecPathExclude = this.GetBiblioSummary_textBox_strBiblioRecPathExclude.Text;

            Properties.Settings.Default.getOperLog_hint = this.GetOperLog_textbox_lHint.Text;
            Properties.Settings.Default.getOperLog_index = this.GetOperLog_textbox_lIndex.Text;
            Properties.Settings.Default.getOperLog_fileName = this.GetOperLog_textbox_strFileName.Text;
            Properties.Settings.Default.getOperLog_attachmentFragmentLength = this.GetOperLog_textbox_nAttachmentFragmentLength.Text;
            Properties.Settings.Default.getOperLog_attachmentFragmentStart = this.GetOperLog_textbox_lAttachmentFragmentStart.Text;

            Properties.Settings.Default.getBrowseRecords_paths = this.GetBrowseRecords_textbox_paths.Text;
            Properties.Settings.Default.getBrowseRecords_browseInfoStyle = this.GetBrowseRecords_textbox_strBrowseInfoStyle.Text;

            Properties.Settings.Default.return_action = this.Return_comboBox_strAction.Text;
            Properties.Settings.Default.return_biblioFormatList = this.Return_textBox_strBiblioFormatList.Text;
            Properties.Settings.Default.getBiblioSummary_confirmItemRecPath = this.Return_textBox_strComfirmItemRecPath.Text;
            Properties.Settings.Default.return_itemBarcode = this.Return_textBox_strItemBarcode.Text;
            Properties.Settings.Default.return_itemFormatList = this.Return_textBox_strItemFormatList.Text;
            Properties.Settings.Default.return_readerBarcode = this.Return_textBox_strReaderBarcode.Text;
            Properties.Settings.Default.return_readerFormatList = this.Return_textBox_strReaderFormatList.Text;
            Properties.Settings.Default.return_style = this.Return_textBox_strStyle.Text;

            Properties.Settings.Default.passGate_readerBarcode = this.PassGate_textBox_strReaderBarcode.Text;
            Properties.Settings.Default.passGate_resultTypeList = this.PassGate_textBox_strResultTypeList.Text;
            Properties.Settings.Default.passGate_gateName = this.PassGate_textBox_strGateName.Text;

            Properties.Settings.Default.getStatisInfo_dateRangeString = this.GetStatisInfo_textBox_strDateRangeString.Text;

            Properties.Settings.Default.getAuthorNumber_strAuthor = this.GetAuthorNumber_textBox_strAuthor.Text;
            Properties.Settings.Default.getAuthorNumber_bSelectPinyin = (bool)this.GetAuthorNumber_checkBox_bSelectPinyin.IsChecked;
            Properties.Settings.Default.getAuthorNumber_bSelectEntry = (bool)this.GetAuthorNumber_checkBox_bSelectEntry.IsChecked;
            Properties.Settings.Default.getAuthorNumber_bOutputDebugInfo = (bool)this.GetAuthorNumber_checkBox_bOutputDebugInfo.IsChecked;

            Properties.Settings.Default.Save();
        }

        string GetMethodUrl(string strMethod)
        {
            if (string.IsNullOrEmpty(this.globalInfo_textBox_url.Text) == true)
                return strMethod;

            if (this.globalInfo_textBox_url.Text[this.globalInfo_textBox_url.Text.Length - 1] == '/')
                return this.globalInfo_textBox_url.Text + strMethod;

            return this.globalInfo_textBox_url.Text + "/" + strMethod;
        }

        static string BuildString(Hashtable table)
        {
            StringBuilder result = new StringBuilder(4096);
            foreach (string key in table.Keys)
            {
                if (result.Length > 0)
                    result.Append(",");
                result.Append("\"" + key + "\":\"" + (string)table[key] + "\"");
            }

            return "{" + result.ToString() + "}";
        }

        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                return obj;
            }
        }

        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        #region Login Logout
        private void login_button_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                /*
                Hashtable table = new Hashtable();
                table["strUserName"] = this.textBox_userName.Text;
                table["strPassword"] = this.textBox_password.Text;

                byte[] baData = Encoding.UTF8.GetBytes(BuildString(table));
                 * */

                LoginRequest request = new LoginRequest();
                request.strUserName = this.login_textBox_userName.Text;
                request.strPassword = this.login_passwordBox.Password;
                request.strParameters = this.login_textBox_parameters.Text + ",client=REST|0.01";// "location=#web,index=-1,type=reader,simulate=yes"; 
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));

                byte[] result = client.UploadData(GetMethodUrl("login"),
                    "POST",
                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                LoginResponse response = Deserialize<LoginResponse>(strResult);

                this.login_textbox_result.Text = "Result:" + response.LoginResult.ErrorCode + response.LoginResult.ErrorInfo
                    + "\r\n Rights:" + response.strRights
                    + "\r\n UserName:" + response.strOutputUserName;
                // this.login_textbox_result.Text = strResult;
                // MessageBox.Show(this, response.LoginResult.ErrorCode.ToString() + response.LoginResult.ErrorInfo + response.LoginResult.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }


        private void login_comboBox_userType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strError = "";
            string strType = (string)((ComboBoxItem)this.login_comboBox_userType.SelectedItem).Content;

            Hashtable table = StringUtil.ParseParameters(this.login_textBox_parameters.Text);
            if (string.IsNullOrEmpty(strType) == true)
                table.Remove("type");
            else
            {
                if (strType == "读者")
                    table["type"] = "reader";
                else if (strType == "工作人员")
                    table["type"] = "worker";
                else
                {
                    strError = "未知的 comboBox_userType.SelectedItem 值 '" + strType + "'";
                    goto ERROR1;
                }
            }

            this.login_textBox_parameters.Text = StringUtil.BuildParameterString(table,
                ',',
                '=');

            return;
            ERROR1:
            MessageBox.Show(this, strError);
        }

        private void login_checkBox_simulate_Checked(object sender, RoutedEventArgs e)
        {
            //string strError = "";
            Hashtable table = StringUtil.ParseParameters(this.login_textBox_parameters.Text);
            if (this.login_checkBox_simulate.IsChecked == false)
                table.Remove("simulate");
            else
            {
                table["simulate"] = "true";
            }

            this.login_textBox_parameters.Text = StringUtil.BuildParameterString(table,
                ',',
                '=');
            return;
            //ERROR1:
            //MessageBox.Show(this, strError);
        }

        private void login_button_logout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                byte[] data = new byte[0];
                byte[] result = client.UploadData(GetMethodUrl("logout"),
                    "POST",
                    data);

                string strResult = Encoding.UTF8.GetString(result);

                LogoutResponse response = Deserialize<LogoutResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #endregion

        #region GetVersion
        private void getVersion_button_getVersion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                byte[] data = new byte[0];
                byte[] result = client.UploadData(GetMethodUrl("getversion"),
                    "POST",
                    data);

                string strResult = Encoding.UTF8.GetString(result);

                GetVersionResponse response = Deserialize<GetVersionResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #endregion

        #region SetLang
        private void setLang_button_setLang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                SetLangRequest request = new SetLangRequest();
                request.strLang = this.setLang_textBox_lang.Text;
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("setlang"),
                    "POST",
                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                SetLangResponse response = Deserialize<SetLangResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #endregion

        #region WriteRes

        // 将文件内容写入资源。这不是单纯的API调用，而是多次调用API实现一个完整的功能
        private void writeRes_button_writeFromFile_Click(object sender, RoutedEventArgs e)
        {
            string strError = "";

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "All files (*.*)|*.*";

            Nullable<bool> dlg_result = dlg.ShowDialog();
            if (dlg_result == false)
                return;


            try
            {
                using (FileStream s = new FileStream(dlg.FileName, FileMode.Open))
                {
                    byte[] baTimestamp = null;
                    int nStart = 0;
                    while (s.Position < s.Length)
                    {
                        byte[] baContent = new byte[Math.Min(4096, s.Length - nStart)];
                        int nLength = s.Read(baContent, 0, baContent.Length);

                        CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                        client.Headers["Content-type"] = "application/json; charset=utf-8";

                        WriteResRequest request = new WriteResRequest();
                        request.strResPath = this.writeRes_textBox_resPath.Text;
                        request.strRanges = nStart.ToString() + "-" + (nStart + nLength - 1).ToString();
                        request.lTotalLength = s.Length;
                        request.baContent = baContent;
                        request.strMetadata = this.writeRes_textBox_metadata.Text;
                        request.strStyle = "";
                        request.baInputTimestamp = baTimestamp;
                        byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                        byte[] result = client.UploadData(GetMethodUrl("WriteRes"),
                            "POST",
                            baData);

                        string strResult = Encoding.UTF8.GetString(result);

                        WriteResResponse response = Deserialize<WriteResResponse>(strResult);

                        // MessageBox.Show(this, strResult);

                        if (response.WriteResResult.Value == -1)
                        {
                            // 第一次的时间戳不匹配，自动重试
                            if (response.WriteResResult.ErrorCode == ErrorCode.TimestampMismatch
                            && nStart == 0)
                            {
                                baTimestamp = response.baOutputTimestamp;
                                s.Position = nStart;
                                continue;
                            }
                            strError = response.WriteResResult.ErrorInfo;
                            goto ERROR1;
                        }
                        nStart += nLength;
                        baTimestamp = response.baOutputTimestamp;
                    }
                }
            }
            catch (Exception ex)
            {
                strError = "Exception :" + ex.Message;
                goto ERROR1;
            }

            MessageBox.Show(this, "WriteRes() complete");
            return;
            ERROR1:
            MessageBox.Show(this, strError);
        }

        private void writeRes_button_writeRes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                WriteResRequest request = new WriteResRequest();
                request.strResPath = this.writeRes_textBox_resPath.Text;
                request.strRanges = this.writeRes_textBox_ranges.Text;
                long lTotalLength = 0;
                if (Int64.TryParse(this.writeRes_textBox_totalLength.Text, out lTotalLength) == false)
                    throw new Exception("lTotalLength参数值 '" + this.writeRes_textBox_totalLength.Text + "' 不正确，应该为纯数字");
                request.lTotalLength = lTotalLength;
                request.baContent = StringUtil.GetTimeStampByteArray(this.writeRes_textBox_content.Text);
                request.strMetadata = this.writeRes_textBox_metadata.Text;
                request.strStyle = this.writeRes_textBox_style.Text;
                request.baInputTimestamp = StringUtil.GetTimeStampByteArray(this.writeRes_textBox_inputTimestamp.Text);
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("writeres"),
                    "POST",
                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                WriteResResponse response = Deserialize<WriteResResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }
        #endregion

        #region GetReaderInfo

        private void getReaderInfo_button_getReaderInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetReaderInfoRequest request = new GetReaderInfoRequest();
                request.strBarcode = this.getReaderInfo_textBox_barcode.Text;
                request.strResultTypeList = this.getReaderInfo_textBox_resultTypeList.Text;
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("getreaderinfo"),
                    "POST",
                    baData);


                // byte[] result = File.ReadAllBytes(@"C:\Users\Administrator\Desktop\result.txt");

                string strResult = Encoding.UTF8.GetString(result);

                GetReaderInfoResponse response = Deserialize<GetReaderInfoResponse>(strResult);

                MessageBox.Show(this, strResult);

                if (response.results != null)
                {
                    string strText = "";
                    int i = 0;
                    foreach (string text in response.results)
                    {
                        strText += "results[" + i.ToString() + "]:\r\n" + text + "\r\n\r\n";
                        i++;
                    }

                    this.getReaderInfo_textBox_results.Text = strText;
                }

                this.getReaderInfo_textBox_timestamp.Text = StringUtil.GetHexTimeStampString(response.baTimestamp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #endregion

        #region SetReaderInfo

        private void setReaderInfo_button_setReaderInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                SetReaderInfoRequest request = new SetReaderInfoRequest();
                request.strAction = this.setReaderInfo_textBox_action.Text;
                request.strRecPath = this.setReaderInfo_textBox_recPath.Text;
                request.strNewXml = this.setReaderInfo_textBox_newXml.Text;
                request.strOldXml = this.setReaderInfo_textBox_oldXml.Text;
                request.baOldTimestamp = StringUtil.GetTimeStampByteArray(this.setReaderInfo_textBox_oldTimestamp.Text);
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("setreaderinfo"),
                    "POST",
                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                SetReaderInfoResponse response = Deserialize<SetReaderInfoResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #endregion

        #region VerifyReaderPassword

        private void verifyReaderPassword_button_verifyReaderPassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                VerifyReaderPasswordRequest request = new VerifyReaderPasswordRequest();
                request.strReaderBarcode = this.verifyReaderPassword_textBox_readerBarcode.Text;
                request.strReaderPassword = this.verifyReaderPassword_passwordBox.Password;
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("verifyreaderpassword"),
                    "POST",
                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                VerifyReaderPasswordResponse response = Deserialize<VerifyReaderPasswordResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #endregion

        #region ChangeReaderPassword

        private void changeReaderPassword_button_changeReaderPassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                ChangeReaderPasswordRequest request = new ChangeReaderPasswordRequest();
                request.strReaderBarcode = this.changeReaderPassword_textBox_readerBarcode.Text;
                request.strReaderOldPassword = this.changeReaderPassword_passwordBox_old.Password;
                request.strReaderNewPassword = this.changeReaderPassword_passwordBox_new.Password;
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("changereaderpassword"),
                    "POST",
                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                ChangeReaderPasswordResponse response = Deserialize<ChangeReaderPasswordResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #endregion

        #region SearchBiblio
        private void SearchBiblio_button_SearchBiblio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                SearchBiblioRequest request = new SearchBiblioRequest();
                request.strQueryWord = this.SearchBiblio_textBox_strQueryWord.Text;
                request.strBiblioDbNames = this.SearchBiblio_comboBox_strBiblioDbNames.Text;
                request.nPerMax = Convert.ToInt32(this.SearchBiblio_textBox_nPerMax.Text);
                request.strLang = this.SearchBiblio_textBox_strLang.Text;
                request.strSearchStyle = this.SearchBiblio_textBox_strSearchStyle.Text;
                request.strOutputStyle = this.SearchBiblio_textBox_strOutputStyle.Text;
                request.strFromStyle = this.SearchBiblio_comboBox_strFromStyle.Text;
                request.strMatchStyle = this.SearchBiblio_comboBox_strMatchStyle.Text;
                request.strResultSetName = this.SearchBiblio_textBox_strResultSetName.Text;

                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("SearchBiblio"),
                                "POST",
                                 baData);

                string strResult = Encoding.UTF8.GetString(result);

                SearchBiblioResponse response = Deserialize<SearchBiblioResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }
        #endregion

        #region GetSearchResult
        private void getSearchResult_button_getSearchResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetSearchResultRequest request = new GetSearchResultRequest();
                request.strResultSetName = this.getSearchResult_textBox_resultsetName.Text;
                request.lStart = Convert.ToInt64(this.getSearchResult_textBox_start.Text);
                request.lCount = Convert.ToInt64(this.getSearchResult_textBox_Count.Text);
                request.strBrowseInfoStyle = this.getSearchResult_textBox_strBrowseInfoStyle.Text;
                request.strLang = this.getSearchResult_textBox_strLang.Text;

                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));

                string strRequest = Encoding.UTF8.GetString(baData);

                byte[] result = client.UploadData(GetMethodUrl("getsearchresult"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                GetSearchResultResponse response = Deserialize<GetSearchResultResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #endregion

        public static class StringUtil
        {
            // 将逗号间隔的参数表解析到Hashtable中
            // parameters:
            //      strText 字符串。形态如 "名1=值1,名2=值2"
            public static Hashtable ParseParameters(string strText,
                char chSegChar = ',',
                char chEqualChar = '=')
            {
                Hashtable results = new Hashtable();

                if (string.IsNullOrEmpty(strText) == true)
                    return results;

                string[] parts = strText.Split(new char[] { chSegChar });   // ','
                for (int i = 0; i < parts.Length; i++)
                {
                    string strPart = parts[i].Trim();
                    if (String.IsNullOrEmpty(strPart) == true)
                        continue;
                    string strName = "";
                    string strValue = "";
                    int nRet = strPart.IndexOf(chEqualChar);    // '='
                    if (nRet == -1)
                    {
                        strName = strPart;
                        strValue = "";
                    }
                    else
                    {
                        strName = strPart.Substring(0, nRet).Trim();
                        strValue = strPart.Substring(nRet + 1).Trim();
                    }

                    if (String.IsNullOrEmpty(strName) == true
                        && String.IsNullOrEmpty(strValue) == true)
                        continue;

                    results[strName] = strValue;
                }

                return results;
            }

            public static string BuildParameterString(Hashtable table,
                char chSegChar = ',',
                char chEqualChar = '=')
            {
                StringBuilder result = new StringBuilder(4096);
                foreach (string key in table.Keys)
                {
                    if (result.Length > 0)
                        result.Append(chSegChar);
                    result.Append(key + new string(chEqualChar, 1) + (string)table[key]);
                }

                return result.ToString();
            }

            // 得到用16进制表示的时间戳字符串
            public static string GetHexTimeStampString(byte[] baTimeStamp)
            {
                if (baTimeStamp == null)
                    return "";
                string strText = "";
                for (int i = 0; i < baTimeStamp.Length; i++)
                {
                    string strHex = Convert.ToString(baTimeStamp[i], 16);
                    strText += strHex.PadLeft(2, '0');
                }

                return strText;
            }

            // 得到byte[]类型的时间戳
            public static byte[] GetTimeStampByteArray(string strHexTimeStamp)
            {
                if (strHexTimeStamp == "")
                    return null;

                byte[] result = new byte[strHexTimeStamp.Length / 2];

                for (int i = 0; i < strHexTimeStamp.Length / 2; i++)
                {
                    string strHex = strHexTimeStamp.Substring(i * 2, 2);
                    result[i] = Convert.ToByte(strHex, 16);

                }

                return result;
            }
        }

        #region SearchReader
        private void SearchReader_button_SearchReader_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                SearchReaderRequest request = new SearchReaderRequest();
                request.strResultSetName = this.SearchReader_textBox_strResultSetName.Text;
                request.strQueryWord = this.SearchReader_textBox_strQueryWord.Text;
                request.nPerMax = Convert.ToInt32(this.SearchReader_textBox_nPerMax.Text);
                request.strFrom = this.SearchReader_comboBox_strFrom.Text;
                request.strLang = this.SearchReader_textBox_strLang.Text;
                request.strReaderDbNames = this.SearchReader_comboBox_strReaderDbNames.Text;
                request.strOutputStyle = this.SearchReader_textBox_strOutputStyle.Text;
                request.strMatchStyle = this.SearchReader_comboBox_strMatchStyle.Text;

                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("SearchReader"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                SearchReaderResponse response = Deserialize<SearchReaderResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        private void SearchReader_comboBox_strReaderDbNames_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetSystemParameterRequest request = new GetSystemParameterRequest()
                {
                    strCategory = "system",
                    strName = "readerDbGroup"
                };
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetSystemParameter"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                // MessageBox.Show(this, strResult);

                GetSystemParameterResponse response = Deserialize<GetSystemParameterResponse>(strResult);

                XmlDocument dom = new XmlDocument();
                dom.LoadXml("<root />");
                try
                {
                    dom.DocumentElement.InnerXml = response.strValue;
                }
                catch (Exception ex)
                {
                    string strError = "category=system,name=readerDbGroup所返回的XML片段在装入InnerXml时出错: " + ex.Message;
                    MessageBox.Show(this, "Error :" + strError);
                }

                this.SearchReader_comboBox_strReaderDbNames.Items.Clear();
                this.SearchReader_comboBox_strReaderDbNames.Items.Add("<全部>");
                XmlNodeList readerDbNames = dom.DocumentElement.SelectNodes("database"); // 未考虑读者库是否参与流通
                foreach (XmlNode name in readerDbNames)
                {
                    string strDbName = name.Attributes["name"].Value;
                    this.SearchReader_comboBox_strReaderDbNames.Items.Add(strDbName);
                }
                this.SearchReader_comboBox_strReaderDbNames.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }
        #endregion

        #region GetItemInfo
        private void GetItemInfo_button_GetItemInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetItemInfoRequest request = new GetItemInfoRequest();
                request.strBarcode = this.GetItemInfo_textBox_strBarcode.Text;
                request.strBiblioType = this.GetItemInfo_comboBox_strBiblioType.Text;
                request.strResultType = this.GetItemInfo_comboBox_strResultType.Text;


                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetItemInfo"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                GetItemInfoResponse response = Deserialize<GetItemInfoResponse>(strResult);

                // this.GetItemInfo_textBox_results.Text = strResult;
                MessageBox.Show(this, strResult);

                if (response.strResult != null)
                    this.GetItemInfo_textBox_results.Text = "results:\r\n" + response.strResult
                        + "\r\n\r\n" + strResult;

                this.GetItemInfo_textBox_baTimestamp.Text = StringUtil.GetHexTimeStampString(response.baTimestamp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }
        #endregion

        #region GetBiblioInfo
        private void GetBiblioInfo_button_GetBiblioInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetBiblioInfoRequest request = new GetBiblioInfoRequest();
                request.strBiblioRecPath = this.GetBiblioInfo_textBox_strBiblioRecPath.Text;
                request.strBiblioType = this.GetItemInfo_comboBox_strBiblioType.Text;


                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetBiblioInfo"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                GetBiblioInfoResponse response = Deserialize<GetBiblioInfoResponse>(strResult);

                MessageBox.Show(this, strResult);

                if (response.strBiblio != null)
                    this.GetBiblioInfo_textBox_result.Text = "results:\r\n" + response.strBiblio + "\r\n\r\n";

                // this.getReaderInfo_textBox_timestamp.Text = StringUtil.GetHexTimeStampString(response.baTimestamp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }
        #endregion

        private void GetEntities_button_GetEntities_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetEntitiesRequest request = new GetEntitiesRequest();
                request.strBiblioRecPath = this.GetEntities_textBox_strBiblioRecPath.Text;
                request.lCount = Convert.ToInt64(this.GetEntities_textBox_lCount.Text);
                request.lStart = Convert.ToInt64(this.GetEntities_textBox_lStart.Text);
                request.strLang = this.GetEntities_textBox_strLang.Text;
                request.strStyle = this.GetEntities_comboBox_strStyle.Text;


                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetEntities"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                GetEntitiesResponse response = Deserialize<GetEntitiesResponse>(strResult);

                // MessageBox.Show(this, strResult);
                this.GetEntities_textBox_results.Text = strResult;
                if (response.entityinfos != null)
                {
                    string strText = "";
                    int i = 0;
                    foreach (EntityInfo text in response.entityinfos)
                    {
                        strText += "results[" + i.ToString() + "]:\r\n" + text.OldRecord + "\r\n\r\n";
                        i++;
                    }
                    this.GetBiblioInfo_textBox_result.Text = strText;
                }

                // this.getReaderInfo_textBox_timestamp.Text = StringUtil.GetHexTimeStampString(response.baTimestamp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        private void GetBiblioSummary_button_GetBiblioSummary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetBiblioSummaryRequest request = new GetBiblioSummaryRequest();
                request.strItemBarcode = this.GetBiblioSummary_textBox_strItemBarcode.Text; // 册条码号
                // request.strItemBarcode = null;
                request.strConfirmItemRecPath = this.GetBiblioSummary_textBox_strConfirmItemRecPath.Text; // 记录路径
                request.strBiblioRecPathExclude = null; // 希望排除掉的书目记录路径


                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetBiblioSummary"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                GetBiblioSummaryResponse response = Deserialize<GetBiblioSummaryResponse>(strResult);

                // MessageBox.Show(this, strResult);
                this.GetBiblioSummary_textBox_results.Text = strResult;


                // this.getReaderInfo_textBox_timestamp.Text = StringUtil.GetHexTimeStampString(response.baTimestamp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        #region 列出信息
        private void ListMessage_button_ListMessage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                ListMessageRequest request = new ListMessageRequest();
                request.strStyle = "search";
                request.strResultsetName = "default";
                request.strBoxType = "收件箱";
                request.messagelevel = MessageLevel.Summary;
                request.nStart = 0;
                request.nCount = -1;

                string str = Serialize(request);

                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("ListMessage"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                ListMessageResponse response = Deserialize<ListMessageResponse>(strResult);

                // MessageBox.Show(this, strResult);
                this.ListMessage_TextBox_results.Text = strResult;


                // this.getReaderInfo_textBox_timestamp.Text = StringUtil.GetHexTimeStampString(response.baTimestamp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }
        #endregion

        #region 获得操作日志
        private void GetOperLog_button_GetOperLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetOperLogRequest request = new GetOperLogRequest();
                request.strFileName = this.GetOperLog_textbox_strFileName.Text;
                request.lIndex = Convert.ToInt64(this.GetOperLog_textbox_lIndex.Text);
                request.lHint = Convert.ToInt64(this.GetOperLog_textbox_lHint.Text);
                request.lAttachmentFragmentStart = Convert.ToInt64(this.GetOperLog_textbox_lAttachmentFragmentStart.Text);
                request.nAttachmentFragmentLength = Convert.ToInt32(this.GetOperLog_textbox_nAttachmentFragmentLength.Text);


                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetOperLog"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                GetOperLogResponse response = Deserialize<GetOperLogResponse>(strResult);

                this.GetOperLog_TextBox_results.Text = strResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }
        #endregion

        private void button_GetBrowseRecords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetBrowseRecordsRequest request = new GetBrowseRecordsRequest();
                request.paths = this.GetBrowseRecords_textbox_paths.Text.Split(new char[] { ',' }); // 记录路径
                request.strBrowseInfoStyle = this.GetBrowseRecords_textbox_strBrowseInfoStyle.Text; // 浏览列样式

                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetBrowseRecords"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);

                // GetBrowseRecordsResponse response = Deserialize<GetBrowseRecordsResponse>(strResult);

                MessageBox.Show(this, strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        private void button_Return_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                ReturnRequest request = new ReturnRequest();
                request.strAction = this.Return_comboBox_strAction.Text;
                request.strStyle = this.Return_textBox_strStyle.Text;
                request.strItemBarcode = this.Return_textBox_strItemBarcode.Text;
                request.strComfirmItemRecPath = this.Return_textBox_strComfirmItemRecPath.Text;
                request.strReaderBarcode = this.Return_textBox_strReaderBarcode.Text;
                request.strBiblioFormatList = this.Return_textBox_strBiblioFormatList.Text;
                request.strItemFormatList = this.Return_textBox_strItemFormatList.Text;
                request.strReaderFormatList = this.Return_textBox_strReaderFormatList.Text;
                request.bForce = false;
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("Return"),
                                                    "POST",
                                                    baData);

                string strResult = Encoding.UTF8.GetString(result);
                this.Return_textbox_result.Text = strResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception :" + ex.Message);
            }
        }

        private void button_PassGate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                PassGateRequest request = new PassGateRequest()
                {
                    strReaderBarcode = this.PassGate_textBox_strReaderBarcode.Text,
                    strGateName = this.PassGate_textBox_strGateName.Text,
                    strResultTypeList = this.PassGate_textBox_strResultTypeList.Text
                };
                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("PassGate"),
                                                    "POST",
                                                    baData);
                string strResult = Encoding.UTF8.GetString(result);
                this.PassGate_textbox_result.Text = strResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void button_GetStatisInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetStatisInfoRequest request = new GetStatisInfoRequest()
                {
                    strDateRangeString = this.GetStatisInfo_textBox_strDateRangeString.Text
                };

                string strInput = Serialize(request);
                this.GetStatisInfo_textbox_input.Text = strInput;

                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetStatisInfo"),
                                                    "POST",
                                                    baData);
                string strResult = Encoding.UTF8.GetString(result);
                this.GetStatisInfo_textbox_output.Text = strResult;


                GetStatisInfoResponse response = Deserialize<GetStatisInfoResponse>(strResult);
                this.GetStatisInfo_textbox_outputXml.Text = response.strXml;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void button_GetAuthorNumber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient(this.cookies);
                client.Headers["Content-type"] = "application/json; charset=utf-8";

                GetAuthorNumberRequest request = new GetAuthorNumberRequest()
                {
                    strAuthor = this.GetAuthorNumber_textBox_strAuthor.Text,
                    bSelectPinyin = (bool)this.GetAuthorNumber_checkBox_bSelectPinyin.IsChecked,
                    bSelectEntry = (bool)this.GetAuthorNumber_checkBox_bSelectEntry.IsChecked,
                    bOutputDebugInfo = (bool)this.GetAuthorNumber_checkBox_bOutputDebugInfo.IsChecked
                };

                string strInput = Serialize(request);
                this.GetStatisInfo_textbox_input.Text = strInput;

                byte[] baData = Encoding.UTF8.GetBytes(Serialize(request));
                byte[] result = client.UploadData(GetMethodUrl("GetAuthorNumber"),
                                                    "POST",
                                                    baData);
                string strResult = Encoding.UTF8.GetString(result);

                MessageBox.Show(this, strResult);


                GetAuthorNumberResponse response = Deserialize<GetAuthorNumberResponse>(strResult);
                this.GetAuthorNumber_textBox_strNumber.Text = response.strNumber;
                this.GetAuthorNumber_textBox_strDebugInfo.Text = response.strDebugInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
    }

    public class CookieAwareWebClient : WebClient
    {
        public CookieAwareWebClient()
            : this(new CookieContainer())
        { }
        public CookieAwareWebClient(CookieContainer c)
        {
            this.CookieContainer = c;
        }
        public CookieContainer CookieContainer { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = this.CookieContainer;
            }
            return request;
        }
    }
}
