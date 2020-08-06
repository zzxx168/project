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
    <title>新增網域</title>
    <style type="text/css">
        .input {
            width: 500px;
            margin-top: 50px;
        }
    </style>

</head>
<body>
<h3 align="center">新增網域</h3>
<div align="center">
    <!--post提交-->
    <form method="post" action="addDomain.php">
        <!--設置name屬性用於提交數據-->      
        <div>網域<input id="domain" name="domain" class="input" type="text"></div>
        <div>連結<input id="domain_web" name="domain_web" class="input" type="text"></div>
        <input name="submit" type="submit" >
    </form>
</div>

</body>
</html>