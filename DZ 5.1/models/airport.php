<?php
    class Airport  {
        private $AirportId;
        private $Iata;
        private $Icao;
        private $Name;

        public function __construct($AirportId = null, $Iata, $Icao, $Name) {
            $this->Iata = $Iata;
            $this->Icao = $Icao;
            $this->Name = $Name;
        }


        public function getAirportID() {
            return $this->AirportId;
        }

        public function getName() {
            return $this->Name;
        }
        public function setName($name) {
            return $this->Name = $name;
        }
        
        public function getIata() {
            return $this->Iata;
        }
        public function setIata($Iata) {
            return $this->Iata = $Iata;
        }

        public function getIcao() {
            return $this->Icao;
        }
        public function setIcao($Icao) {
            return $this->Icao = $Icao;
        }



        public static function getAllAirports() {
            $airports = [];
            $db = Db::getInstance();
            $request = $db->query('SELECT * FROM airport');
                foreach($request->fetchAll() as $airp) {
                $list[] = new Airport($airp['AirportId'], $airp['Iata'], $airp['Icao'], $airp['Name']);
            }

            return $airports;
          }


          public static function findById($id) {
            $db = Db::getInstance();
            $id = intval($id);

            $request = $db->prepare('SELECT * FROM airport WHERE AirportId = :id');
            $request->execute(array('id' => $id));
            $airport = $request->fetch();
            
            if ($airport) {
                return new Airport($airport['AirportId'], $airport['Name'], $airport['Icao'], $airport['Iata']);
            } else {
                return [];
            }
          }


          public function editAirportById($id, $newName, $newIata, $newIcao){
            $db = Db::getInstance();
            $id = intval($id);

            $sql = "UPDATE airport SET 'Name' = '$newName', 'Iata' = '$newIata', 'Icao' = '$newIcao') VALUES WHERE AirportId = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="Airport updated!";
            } else {
                $rez="Airport not updated!";;
            }
            
            return $rez; 
          }


          public function addAirport($Name, $Iata, $Icao){
            $db = Db::getInstance();

            $sql = "INSERT INTO airport (`Name`, `Iata`, 'Icao') VALUES ('$Name', '$Iata', '$Icao')";

            if ($db->query($sql) == TRUE){
                $rez="Airport added!";
            } else {
                $rez="Airport not added!";;
            }
            
            return $rez; 
          }


          public static function deleteAirportById($id) {
            $db = Db::getInstance();
            $sql = "DELETE FROM Airport WHERE AirportId = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="Airport deleted";
            } else {
                $rez="Deletion error!";;
            }
            
            return $rez; 
        }
    }
?>