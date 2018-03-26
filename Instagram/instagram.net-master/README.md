instagramdotnet
===============

C# Wrapper for Instagram Rest API

## Synopsis

instagram.net is a class which you can use to interact with Instagram's API endpoints. It's a simple plugin that allows you to access public streams in under 5 lines of code. If you have any questions please find me on twitter @codechmst

## Endpoints

This library covers the following endpoints:

1. Users Search [GET /users/search] - https://instagram.com/developer/endpoints/users/#get_users_search
2. Media Recent [GET /users/user-id/media/recent] - https://instagram.com/developer/endpoints/users/#get_users_media_recent

## Installation

You must download and add a reference to json.net
http://james.newtonking.com/json

## Code Example

In your code behind

    using InstagramDotNet;
  
    Instagram ig = new Instagram("YOUR_ACCESS_TOKEN");
  
    //Outputs the numeric value of a username
    //returns a JSON String containing the user id value
    ig.getUserId("USER_NAME");
  
    //Bound to your repeater in your .aspx page
    Repeater1.DataSource = ig.getMediaRecent("INSTAGRAM_USER_ID", 10);
    Repeater1.DataBind();
    
In your .aspx page
    
    <asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>
          <div>
              <img src='<%# Eval("SmallImage") %>' alt='<%# Eval("Caption") %>' />
              <p><%# Eval("Tags") %></p>
              <p>&hearts; <%# Eval("Likes") %></p>
          </div>
      </ItemTemplate>
    </asp:Repeater>

##Reference

1. http://instagram.com/developer/endpoints/

## License

MIT license
