<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <style>
        .submit{
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            alignment: center;
            margin: 0 auto;
            border: none;
            cursor: pointer;
            width: 10%;
            display:block;
        }
        .radio{
            color: white;
            padding: 14px 20px;
            alignment: center;
            margin: 0 auto;
            border: none;
            cursor: pointer;
            width: 10%;
            display:block;
            text-align: center;
        }
        div{
         text-align: center;
        }
    </style>
    <title>Servlet2</title>
    <meta charset="UTF-8">
</head>
<body>
<form action="http://localhost:8080/OOP_Lab2_war/task2" method="get">
    <div>
        <input class="radio" type = "radio" id = "Method1" name = "contact" value="1"> GetID
        <input class="radio" type = "radio" id = "Method2" name = "contact" value="2"> Time
        <input class="radio" type = "radio" id = "Method3" name = "contact" value="3"> count
    </div>
    <input class="submit" type="submit" value="Submit">
</form>
</body>
</html>



