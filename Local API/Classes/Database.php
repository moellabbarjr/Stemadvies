<?php
class Database
{
    public function Connect() {
        $host = '127.0.0.1';
        $database = 'stemadvies';
        $user = 'root';
        $pass = '4037';

        $dns = "mysql:host=$host;dbname=$database";

        $options = [
            PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
            PDO::ATTR_EMULATE_PREPARES => false,
            PDO::ATTR_STRINGIFY_FETCHES => false
        ];

        return new PDO($dns, $user, $pass, $options);
    }
}