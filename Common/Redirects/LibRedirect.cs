using Microsoft.AspNetCore.Mvc;

namespace Common.Redirects
{
    public static class LibRedirect
    {
        public const string ToCatalogPageUrl = "/Books/List";
        public const string ToCreateAuthorPageUrl = "/Authors/Create";
        public const string ToCreateBookTypePageUrl = "/BookTypes/Create";
        public const string ToCreateGenrePageUrl = "/Genres/Create";
        public const string ToCreatePublisherPageUrl = "/Publishers/Create";
        public const string ToSignInPageUrl = "/Account/Authorization";
        public const string ToUploadBookPageUrl = "/Books/Upload";

        public static IActionResult ToMainPage() =>
            new RedirectToPageResult("/Index");
    }
}
