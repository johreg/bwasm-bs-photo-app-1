using auth_api_1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using System.Text.Json;

namespace wasm_bs_photo_app_1.Pages
{
    public partial class MyImagesTest2Api
    {
        bool expanded = false;
        bool isUploading = false;  // To track the upload state
        private string? selectedUrlSnippet;
        PagedResponse? imageCardPage;
        //  ImageBlobFolderStructure? folderStructure;
        List<string?>? allImageFolders;
        Dictionary<string, bool>? folderExpandedState = new Dictionary<string, bool>();
        string? userobjectid;
        string? tenantid;
        string? currentbase64Image;
    //    ImageMetadataResponse imageMetadata;
        string disabledButtonText = "Uploading...";
        string enabledButtonText = "Upload Images";
        HttpClient? _httpClient;
        string selectedFolder = "";

       // FluentInputFile? myFileByBuffer = default!;
        int? progressPercent;
        string? progressTitle;
        bool IsCanceled;
        bool fluentNavLinkClicked = false;

        Dictionary<int, string> Files = new();

        string userObjectIdDebug = "userdataobjectidtest2"; //userdataobjectidtest1

        // private IDialogReference? _dialog;

        //    [Inject]
        //    protected IDialogService? DialogService { get; set; }


        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;


        private void NavigateToImage(int id)
        {
            NavigationManager.NavigateTo($"/myimagestest2api/myimage{id}");
        }


        protected override async Task OnInitializedAsync()
        {
            #region _debug
#if DEBUG
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44336/");
            userobjectid = userObjectIdDebug;
            tenantid = "1";
#else
            _httpClient = HttpCl;
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            userobjectid = authState.User.Claims.FirstOrDefault(c => c.Type == "oid")?.Value; // User ID
            tenantid = authState.User.Claims.FirstOrDefault(c => c.Type == "tid")?.Value;
#endif
            #endregion

            await ReloadFolderStructureAsync(userobjectid, tenantid, _httpClient);
        }

        private async Task ReloadFolderStructureAsync(string userobjectid, string tenantid, HttpClient httpClient)
        {
            try 
            { 
            var queryString = $"?TenantId={tenantid}&UserObjectId={userobjectid}";

            imageCardPage = await httpClient.GetFromJsonAsync<PagedResponse>($"JoretecTestApi/GetImagesByOwner?ownerUserId=129837109832091");

                var gg = imageCardPage;  

            }
            catch (Exception e)
            {
                var aa = e;
            }
        //    allImageFolders = folderStructure?.Folders?.Select(f => f.Name).Where(name => name != null).ToList();

            /*
            folderExpandedState = new Dictionary<string, bool>();

            if (folderStructure?.Folders != null)
            {
                foreach (var folder in folderStructure.Folders)
                {
                    folderExpandedState[folder.Name] = false;
                }
            }
            */

        }


        private IBrowserFile? selectedFile;
        private string? FileName;

        private async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            FileName = selectedFile.Name;
        }

        private async Task UploadFile()
        {
            if (selectedFile is null)
            {
                Console.WriteLine("No file selected.");
                return;
            }

            try
            {
                // Convert file to a stream
                using var stream = selectedFile.OpenReadStream(10 * 1024 * 1024); // 10MB max size
                var content = new MultipartFormDataContent
            {
                { new StreamContent(stream), "file", selectedFile.Name }
            };

                // Send to your API
             //   using var httpClient = new HttpClient();
                var response = await _httpClient.PostAsync($"JoretecTestApi/UploadNewImageV2", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Upload successful!");
                }
                else
                {
                    Console.WriteLine("Upload failed: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Upload error: {ex.Message}");
            }
        }


    }
}