<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <style>
        h1 {text-align: center; color: darkviolet}
    </style>
    <title>Music Collection</title>
</head>
<body>
<h1><%= "Music Collection" %></h1>

<br>Main Menu<br>
<ul>
    <li><a href="html/view_music.html">View music</a> </li>
    <li><a href="html/add_music.html">Add music</a> </li>
    <li><a href="html/delete_music.html">Delete music</a> </li>
</ul>
<br><br>

<button type="button" name="back" onclick="history.back()">Go back</button>

</body>
</html>
