<?php
session_start();

//導入config
include_once('config.php');
//檢查用
// echo $_SESSION["login_limit"];

//查詢資料表limit_ip
$query1 = "select * from limit_ip ;";
$result1 = $pdo->prepare($query1);
$result1->execute();
$rows1=$result1->fetchAll(PDO::FETCH_ASSOC);

//將被限制ip存入陣列
$ipArray =[];
foreach ($rows1 as  $value) {
    $ipArray[] = $value["ip"];
}

//獲取當前使用者ip
$userip = $_SERVER['REMOTE_ADDR'];
?>

<!DOCTYPE html>
<html lang="en" class="is-centered is-bold">
<head>
    <meta charset="UTF-8">
    <title>網域監控登入</title>
    <link href="css/main.css" rel="stylesheet">
</head>
<body>
<section style="background: transparent">
    <form class="box py-3 px-4 px-2-mobile" role="form" method="post" action="checkLogin.php">
        <div class="is-flex is-column is-justified-to-center">
            <h1 class="title is-3 mb-a has-text-centered">
                登入
            </h1>
            <div class="inputs-wrap py-3">
            <!-- 做if判斷，當前ip如果不在限制名單中，則可以登入 -->
            <?php if(!in_array($userip, $ipArray)) : ?>
                <div class="control">
                    <input type="text" id="username" name="username" class="input" placeholder="帳號" value="" required >
                </div>
                <div class="control">
                    <input type="password" id="password" name="password" class="input" placeholder="密碼" required >
                </div>
                <div class="control">
                    <button type="submit" class="button is-submit is-primary is-outlined" >
                       提交
                    </button>    
                </div>
            <!-- 當前ip如果在限制名單中，則不能登入  -->
            <?php else : ?>    
                <div class="control">
                    <input type="text" id="username" name="username" class="input" placeholder="帳號" value="" required disabled>
                </div>
                <div class="control">
                    <input type="password" id="password" name="password" class="input" placeholder="密碼" required disabled>
                </div>
                <div class="control">
                    <button type="submit" class="button is-submit is-primary is-outlined" disabled>
                       提交
                    </button>    
                </div>
                <div class="control" >
                    <div style="color: red" align="center">此ip被限制登入</div>
                </div>
            <?php endif ; ?>    
            </div>
            <footer class="is-flex is-justified-space-between">
               
            </footer>
        </div>
    </form>
</section>
<script>
   
</script>
</body>
</html>
