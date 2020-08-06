<?php
session_start();
// 登入判斷
if(!isset($_SESSION['username'])){
    echo "<script>alert('請先登入');window.location.href='login.php'</script>";
} 
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>刪除網址</title>
    <style type="text/css">
        .input {
            width: 500px;
            margin-top: 50px;
        }
    </style>
</head>
<body>
<h3 align="center">刪除網址</h3>
<div align="center">
    <!--post提交-->
    <form method="post" action="deleteWeb.php" onsubmit="">
        <!--設置name屬性用於提交數據-->      
        <div>網址<input id="web" name="web" class="input" type="text"></div>
        <br>
        <div><input name="submit" type="submit" ></div>
    </form>
</div>

</body>
</html>