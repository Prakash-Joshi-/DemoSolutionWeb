<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TwitterAPI_Demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .SuggestionList-highlight{color:#1b95e0;font-weight:700}
    </style>
    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    <div class="row SuggestionList-highlight" id="SuggestionList">
        <div>A collection: <span style="color:red;">"https://twitter.com/TwitterDev/timelines/539487832448843776"</span> </div>
        <div>A Tweet: "https://twitter.com/Interior/status/463440424141459456"</div>
        <div>A profile: "https://twitter.com/TwitterDev"</div>
        <div>A likes timeline: "https://twitter.com/TwitterDev/likes"</div>
        <div>A list: "https://twitter.com/TwitterDev/lists/national-parks"</div>
        <div>A likes timeline: "https://twitter.com/TwitterDev/likes"</div>
        <div>A handle, like "@TwitterDev"</div>
        <div>A hashtag, like "#LoveTwitter"</div>
    </div>
    <div class="row SuggestionList-highlight" id="SuggestionList1">
        <div>A collection: <span>"https://twitter.com/TwitterDev/timelines/539487832448843776"</span> </div>
        <div>A Tweet:<span> "https://twitter.com/Interior/status/463440424141459456"</span></div>
        <div>A profile:<span> "https://twitter.com/TwitterDev"</span></div>
        <div>A likes timeline: <span>"https://twitter.com/TwitterDev/likes"</span></div>
        <div>A list: <span>"https://twitter.com/TwitterDev/lists/national-parks"</span></div>
        <div>A likes timeline: <span>"https://twitter.com/TwitterDev/likes"</span></div>
        <div>A handle, like "@TwitterDev"</div>
        <div>A hashtag, like "#LoveTwitter"</div>
    </div>
    <div class="row">
        <div class="col-md-6">
            https://publish.twitter.com/
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <a href="https://twitter.com/intent/tweet?button_hashtag=LoveTwitter" class="twitter-hashtag-button" data-show-count="false">Tweet #LoveTwitter</a><script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <a href="https://twitter.com/intent/tweet?screen_name=prakash_joshi_" class="twitter-mention-button" data-show-count="false">Tweet to @prakash_joshi_</a><script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <a href="https://twitter.com/prakash_joshi_" class="twitter-follow-button" data-show-count="false">Follow @prakash_joshi_</a><script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4" style="background: #001b34;">
            <a class="twitter-timeline" href="https://twitter.com/prakash_joshi_">Tweets by prakash_joshi_</a> <script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#SuggestionList div').each(function (index, element) {
                var text = element.innerText;
                $(element).css('color', 'red');
                alert(element.innerText);
            });
            $('#SuggestionList1 div').each(function (index, element) {
                var text = element.innerText;
                $(element).find('span').css('color', 'red');
                alert($("#SuggestionList1 div:contains('profile')").val());
                alert(element.innerText);
            });
           
        });
    </script>
</asp:Content>
