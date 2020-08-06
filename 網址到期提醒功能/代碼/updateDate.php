<?php
//導入config
include_once('config.php');

//獲取POST方式提交的數據
$web = trim($_POST['web']);
$date = trim($_POST["date"]);
$id = trim($_POST["id"]);


//mysql更新語句
$sql="update domain set expiry_date = ?, id = ? where web = ? ";

//執行mysql語句
$result = $pdo->prepare($sql);
$result->execute([$date, $id, $web]);

//回到主頁
echo "<script> window.location.href='index.php';</script>";

