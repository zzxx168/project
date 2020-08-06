<?php

//導入config
include_once('config.php');
//獲取id
$id=$_GET['id'];

//mysql刪除語句
$query1 = "delete from domain_backup where id = ? ";
//執行mysql語句
$result1 = $pdo->prepare($query1);
$result1->execute([$id]);

// 回到套用備份頁面
echo "<script>window.location.href='showBackup.php'; </script>";
?>


<!-- <script>window.location.href='showBackup.php'; </script> -->