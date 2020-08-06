<?php
//導入config
include_once('config.php');
//獲取網址
$web=$_POST['web'];

//mysql刪除語句
$sql="delete from domain where web = ?";

//執行mysql語句
$result = $pdo->prepare($sql);
$result->execute([$web]);


echo "<script> window.location.href='index.php';</script>";