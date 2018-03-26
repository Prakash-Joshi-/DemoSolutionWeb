<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InstagramDemoAsp.net._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>Getting Started</h5>
            ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a>
        </li>
        <li class="two">
            <h5>Add NuGet packages and jump-start your coding</h5>
            NuGet makes it easy to install and update free libraries and tools.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a>
        </li>
        <li class="three">
            <h5>Find Web Hosting</h5>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a>
        </li>
    </ol>
    <h1>Instagram Authentication Sample</h1>

    <div>
        <asp:Button ID="btnAuthenticate" runat="server" Text="Authenticate Instagram" OnClick="btnAuthenticate_Click" />
    </div>
    <div>
        <h1>About Me</h1>
        <div style="font-size: medium;">
            User ID:
            <label id="userIDLabel"></label>
        </div>
        <div style="font-size: medium;">
            User Name:  
                <label id="usernameLabel"></label>
        </div>
        <div style="font-size: medium;">
            Full Name:  
                <label id="nameLabel"></label>
        </div>
        <div style="font-size: medium;">
            Profile Pic:  
                <img id="imgProfilePic" />
        </div>
        <div style="font-size: medium;">
            Bio:  
                <label id="bioLabel"></label>
        </div>
        <div style="font-size: medium;">
            Website:  
                <label id="websiteLabel"></label>
        </div>
        <div style="font-size: medium;">
            Counts:  
                <label id="mediaLabel">Media: </label>
            <label id="followsLabel">Follows: </label>
            <label id="followed_byLabel">Followed by: </label>
        </div>
    </div>

    <div>
        <h1>Recent Photos</h1>
        <div id="PhotosDiv">
            <ul id="PhotosUL">
            </ul>
        </div>
    </div>
    <div style="clear: both;"></div>


    <div>
        <h1>Popular Pictures</h1>
        <div id="PopularPhotosDiv">
            <ul id="photosUL1">
            </ul>
        </div>
    </div>

    <div>
        <h1>Popular Pictures new</h1>
        <div id="PopularPhotos2Div">
            <ul id="photosUL2">
            </ul>
        </div>
    </div>

    <div>
        <h1>Popular Pictures new</h1>
        <div id="TagPhotosDiv">
            <ul id="TagPhotosUL">
            </ul>
        </div>
    </div>

    <div>
        <h1>About other</h1>
        <div style="font-size: medium;">
            User Name:  
                <label id="usernameLabel1"></label>
        </div>
        <div style="font-size: medium;">
            Full Name:  
                <label id="nameLabel1"></label>
        </div>
        <div style="font-size: medium;">
            Profile Pic:  
                <img id="imgProfilePic1" />
        </div>
        <div style="font-size: medium;">
            Bio:  
                <label id="bioLabel1"></label>
        </div>
    </div>




    <script>
        $(document).ready(function () {
            GetUserDetails();
            GetInstagramPhotos();
            //GetPopularPhotos();
            GetPopularPhotos1();
            GetOtherUserDetails();
        });

        //Get user details  
        function GetUserDetails() {
            $.ajax({
                type: "GET",
                async: true,
                contentType: "application/json; charset=utf-8",
                url: 'https://api.instagram.com/v1/users/' + instagramaccessid + '?access_token=' + instagramaccesstoken,
                dataType: "jsonp",
                cache: false,
                beforeSend: function () {
                    $("#loading").show();
                },
                success: function (data) {
                    $('#userIDLabel').text(data.data.id);
                    $('#usernameLabel').text(data.data.username);
                    $('#nameLabel').text(data.data.full_name);
                    $('#bioLabel').text(data.data.bio);
                    $('#websiteLabel').text(data.data.website);
                    $('#mediaLabel').append(data.data.counts.media);
                    $('#followsLabel').append(data.data.counts.follows);
                    $('#followed_byLabel').append(data.data.counts.followed_by);
                    document.getElementById("imgProfilePic").src = data.data.profile_picture;
                }
            });
        }

        //Get other user details 
        function GetOtherUserDetails() {

            $.ajax({
                type: "GET",
                async: true,
                contectType: "application/json; charset=utf-8",
                url: 'https://api.instagram.com/v1/users/807707178/?access_token=' + instagramaccesstoken,
                dataType: "jsonp",
                success: function (data) {
                    $('#usernameLabel1').text(data.data.username)
                }
            });
        }

        //Get photos  
        function GetInstagramPhotos() {
            $("#PhotosUL").html("");

            $.ajax({
                type: "GET",
                async: true,
                contentType: "application/json; charset=utf-8",
                //Recent user photos  
                url: 'https://api.instagram.com/v1/users/' + instagramaccessid + '/media/recent?access_token=' + instagramaccesstoken,
                //Most popular photos  
                //url: "https://api.instagram.com/v1/media/popular?access_token=" + instagramaccesstoken,  
                //For most recent pictures from a specific location:  
                //url:  "https://api.instagram.com/v1/media/search?lat=[LAT]&lng=[LNG]&distance=[DST]?client_id=[ClientID]&access_token=[CODE]",  
                //For min and max images  
                //url: "https://api.instagram.com/v1/users/"+ userId+ "/media/recent/"+ "?access_token="+ token+ "&count=" + mediaCount+ "&max_id=" + mOldestId",  
                //By Tags  
                //url: "https://api.instagram.com/v1/tags/coffee/media/recent?client_id=[]&access_token=[]",  
                // url https://api.instagram.com/v1/tags/nofilter/media/recent?access_token=ACCESS_TOKEN
                // url https://api.instagram.com/v1/tags/{tag-name}/media/recent?access_token=ACCESS-TOKEN
                //To get a user’s detail  
                //url: "https://api.instagram.com/v1/users/usert_id/?access_token=youraccesstoken",  
                dataType: "jsonp",
                cache: false,
                beforeSend: function () {
                    $("#loading").show();
                },
                success: function (data) {
                    $("#loading").hide();
                    if (data == "") {
                        $("#PhotosDiv").hide();
                    } else {

                        $("#PhotosDiv").show();
                        for (var i = 0; i < data["data"].length; i++) {
                            $("#PhotosUL").append("<li style='float:left;list-style:none;'><a target='_blank' href='" + data.data[i].link + "'><img src='" + data.data[i].images.thumbnail.url + "'></img></a></li>");
                        }

                    }
                }

            });
        }


        //Get popular pictures  
        //function GetPopularPhotos() {
        //    $("#photosUL1").html("");
        //    debugger;
        //    $.ajax({
        //        type: "GET",
        //        async: true,
        //        contentType: "application/json; charset=utf-8",
        //        //Most popular photos  
        //        url: 'https://api.instagram.com/v1/media/popular?access_token=' + instagramaccesstoken,
        //        dataType: "jsonp",
        //        cache: false,
        //        beforeSend: function () {
        //            $("#loading").show();
        //        },
        //        success: function (data) {
        //            $("#loading").hide();
        //            debugger;
        //            if (data == "") {
        //                $("#PopularPhotosDiv").hide();
        //            } else {
        //                $("#PopularPhotosDiv").show();
        //                for (var i = 0; i < data["data"].length; i++) {
        //                    $("#photosUL1").append("<li style='float:left;list-style:none;'><a target='_blank' href='" + data.data[i].link + "'><img src='" + data.data[i].images.thumbnail.url + "'></img></a></li>");
        //                }

        //            }
        //        }

        //    });
        //}

        //Get popular pictures new  
        function GetPopularPhotos1() {
            $("#photosUL2").html("");
            debugger;
            $.ajax({
                type: "GET",
                async: true,
                contentType: "application/json; charset=utf-8",
                //Most popular photos  
                url: 'https://www.instagram.com/smena8m/media/?min_id=1045341392067624850_3108326',
                dataType: "jsonp",
                cache: false,
                beforeSend: function () {
                    $("#loading").show();
                },
                success: function (data) {
                    $("#loading").hide();
                    debugger;
                    if (data == "") {
                        alert();
                        $("#PopularPhotos2Div").hide();
                    } else {
                        $("#PopularPhotos2Div").show();
                        $("#photosUL1").append("<li style='float:left;list-style:none;'><a target='_blank' href='" + data.items.images.standard_resolution.url + "'><img src='" + data.items.images.standard_resolution.url + "'></img></a></li>");
                        //for (var i = 0; i < data["items"].length; i++) {
                        //    $("#photosUL1").append("<li style='float:left;list-style:none;'><a target='_blank' href='" + data.items[i].link + "'><img src='" + data.data[i].images.thumbnail.url + "'></img></a></li>");
                        //}

                    }
                }

            });
        }

        //Get popular pictures new  
        function GetTagPhotos() {
            $("#TagPhotosUL").html("");
            debugger;
            $.ajax({
                type: "GET",
                async: true,
                contentType: "application/json; charset=utf-8",
                //Most popular photos  
                url: 'https://api.instagram.com/v1/tags/utsavfashion/media/recent?access_token=ACCESS-TOKEN',
                dataType: "jsonp",
                cache: false,
                beforeSend: function () {
                    $("#loading").show();
                },
                success: function (data) {
                    $("#loading").hide();
                    debugger;
                    if (data == "") {
                        alert();
                        $("#TagPhotosDiv").hide();
                    } else {
                        $("#TagPhotosDiv").show();
                        $("#TagPhotosUL").append("<li style='float:left;list-style:none;'><a target='_blank' href='" + data.items.images.standard_resolution.url + "'><img src='" + data.items.images.standard_resolution.url + "'></img></a></li>");
                        //for (var i = 0; i < data["items"].length; i++) {
                        //    $("#TagPhotosUL").append("<li style='float:left;list-style:none;'><a target='_blank' href='" + data.items[i].link + "'><img src='" + data.data[i].images.thumbnail.url + "'></img></a></li>");
                        //}

                    }
                }

            });
        }


    </script>
</asp:Content>
