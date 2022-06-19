using System;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace App
{
    public partial class airportdbContext : DbContext
    {
        public airportdbContext()
        {
        }

        public airportdbContext(DbContextOptions<airportdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<AirplaneType> AirplaneTypes { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<AirportGeo> AirportGeos { get; set; }
        public virtual DbSet<AirportReachable> AirportReachables { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightLog> FlightLogs { get; set; }
        public virtual DbSet<Flightschedule> Flightschedules { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Passengerdetail> Passengerdetails { get; set; }
        public virtual DbSet<Weatherdatum> Weatherdata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3307;user=root;database=airportdb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.16-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("airline");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BaseAirport, "base_airport_idx");

                entity.HasIndex(e => e.Iata, "iata_unq")
                    .IsUnique();

                entity.Property(e => e.AirlineId)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("airline_id");

                entity.Property(e => e.Airlinename)
                    .HasMaxLength(30)
                    .HasColumnName("airlinename");

                entity.Property(e => e.BaseAirport)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("base_airport");

                entity.Property(e => e.Iata)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("iata")
                    .IsFixedLength(true);

                entity.HasOne(d => d.BaseAirportNavigation)
                    .WithMany(p => p.Airlines)
                    .HasForeignKey(d => d.BaseAirport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("airline_ibfk_1");
            });

            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.ToTable("airplane");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.TypeId, "type_id");

                entity.Property(e => e.AirplaneId)
                    .HasColumnType("int(11)")
                    .HasColumnName("airplane_id");

                entity.Property(e => e.AirlineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("airline_id");

                entity.Property(e => e.Capacity)
                    .HasColumnType("mediumint(8) unsigned")
                    .HasColumnName("capacity");

                entity.Property(e => e.TypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Airplanes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("airplane_ibfk_1");
            });

            modelBuilder.Entity<AirplaneType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PRIMARY");

                entity.ToTable("airplane_type");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Identifier, e.Description }, "description_full")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.Property(e => e.TypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("type_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Identifier)
                    .HasMaxLength(50)
                    .HasColumnName("identifier");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("airport");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Iata, "iata_idx");

                entity.HasIndex(e => e.Icao, "icao_unq")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "name_idx");

                entity.Property(e => e.AirportId)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("airport_id");

                entity.Property(e => e.Iata)
                    .HasMaxLength(3)
                    .HasColumnName("iata")
                    .IsFixedLength(true);

                entity.Property(e => e.Icao)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("icao")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AirportGeo>(entity =>
            {
                entity.HasKey(e => e.AirportId)
                    .HasName("PRIMARY");

                entity.ToTable("airport_geo");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AirportId)
                    .HasColumnType("smallint(6)")
                    .ValueGeneratedNever()
                    .HasColumnName("airport_id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Latitude)
                    .HasPrecision(11, 8)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasPrecision(11, 8)
                    .HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Airport)
                    .WithOne(p => p.AirportGeo)
                    .HasForeignKey<AirportGeo>(d => d.AirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("airport_geo_ibfk_1");
            });

            modelBuilder.Entity<AirportReachable>(entity =>
            {
                entity.HasKey(e => e.AirportId)
                    .HasName("PRIMARY");

                entity.ToTable("airport_reachable");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AirportId)
                    .HasColumnType("smallint(6)")
                    .ValueGeneratedNever()
                    .HasColumnName("airport_id");

                entity.Property(e => e.Hops)
                    .HasColumnType("int(11)")
                    .HasColumnName("hops");

                entity.HasOne(d => d.Airport)
                    .WithOne(p => p.AirportReachable)
                    .HasForeignKey<AirportReachable>(d => d.AirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("airport_reachable_ibfk_1");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.FlightId, "flight_idx");

                entity.HasIndex(e => e.PassengerId, "passenger_idx");

                entity.HasIndex(e => new { e.FlightId, e.Seat }, "seatplan_unq")
                    .IsUnique();

                entity.Property(e => e.BookingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("booking_id");

                entity.Property(e => e.FlightId)
                    .HasColumnType("int(11)")
                    .HasColumnName("flight_id");

                entity.Property(e => e.PassengerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("passenger_id");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.Seat)
                    .HasMaxLength(4)
                    .HasColumnName("seat")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_ibfk_1");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_ibfk_2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Username, "user_unq")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("country");

                entity.Property(e => e.Department)
                    .HasColumnType("enum('Marketing','Buchhaltung','Management','Logistik','Flugfeld')")
                    .HasColumnName("department");

                entity.Property(e => e.Emailaddress)
                    .HasMaxLength(120)
                    .HasColumnName("emailaddress");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.Salary)
                    .HasPrecision(8, 2)
                    .HasColumnName("salary");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("street");

                entity.Property(e => e.Telephoneno)
                    .HasMaxLength(30)
                    .HasColumnName("telephoneno");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .HasColumnName("username");

                entity.Property(e => e.Zip)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("zip");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AirlineId, "airline_idx");

                entity.HasIndex(e => e.AirplaneId, "airplane_idx");

                entity.HasIndex(e => e.Arrival, "arrivals_idx");

                entity.HasIndex(e => e.Departure, "departure_idx");

                entity.HasIndex(e => e.Flightno, "flightno");

                entity.HasIndex(e => e.From, "from_idx");

                entity.HasIndex(e => e.To, "to_idx");

                entity.Property(e => e.FlightId)
                    .HasColumnType("int(11)")
                    .HasColumnName("flight_id");

                entity.Property(e => e.AirlineId)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("airline_id");

                entity.Property(e => e.AirplaneId)
                    .HasColumnType("int(11)")
                    .HasColumnName("airplane_id");

                entity.Property(e => e.Arrival)
                    .HasColumnType("datetime")
                    .HasColumnName("arrival");

                entity.Property(e => e.Departure)
                    .HasColumnType("datetime")
                    .HasColumnName("departure");

                entity.Property(e => e.Flightno)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("flightno")
                    .IsFixedLength(true);

                entity.Property(e => e.From)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("from");

                entity.Property(e => e.To)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("to");

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_ibfk_3");

                entity.HasOne(d => d.Airplane)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirplaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_ibfk_4");

                entity.HasOne(d => d.FlightnoNavigation)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.Flightno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_ibfk_5");

                entity.HasOne(d => d.FromNavigation)
                    .WithMany(p => p.FlightFromNavigations)
                    .HasForeignKey(d => d.From)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_ibfk_1");

                entity.HasOne(d => d.ToNavigation)
                    .WithMany(p => p.FlightToNavigations)
                    .HasForeignKey(d => d.To)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_ibfk_2");
            });

            modelBuilder.Entity<FlightLog>(entity =>
            {
                entity.ToTable("flight_log");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.FlightId, "flight_log_ibfk_1");

                entity.Property(e => e.FlightLogId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("flight_log_id");

                entity.Property(e => e.AirlineIdNew)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("airline_id_new");

                entity.Property(e => e.AirlineIdOld)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("airline_id_old");

                entity.Property(e => e.AirplaneIdNew)
                    .HasColumnType("int(11)")
                    .HasColumnName("airplane_id_new");

                entity.Property(e => e.AirplaneIdOld)
                    .HasColumnType("int(11)")
                    .HasColumnName("airplane_id_old");

                entity.Property(e => e.ArrivalNew)
                    .HasColumnType("datetime")
                    .HasColumnName("arrival_new");

                entity.Property(e => e.ArrivalOld)
                    .HasColumnType("datetime")
                    .HasColumnName("arrival_old");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .HasColumnName("comment");

                entity.Property(e => e.DepartureNew)
                    .HasColumnType("datetime")
                    .HasColumnName("departure_new");

                entity.Property(e => e.DepartureOld)
                    .HasColumnType("datetime")
                    .HasColumnName("departure_old");

                entity.Property(e => e.FlightId)
                    .HasColumnType("int(11)")
                    .HasColumnName("flight_id");

                entity.Property(e => e.FlightnoNew)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("flightno_new")
                    .IsFixedLength(true);

                entity.Property(e => e.FlightnoOld)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("flightno_old")
                    .IsFixedLength(true);

                entity.Property(e => e.FromNew)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("from_new");

                entity.Property(e => e.FromOld)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("from_old");

                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                    .HasColumnName("log_date");

                entity.Property(e => e.ToNew)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("to_new");

                entity.Property(e => e.ToOld)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("to_old");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("user");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightLogs)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_log_ibfk_1");
            });

            modelBuilder.Entity<Flightschedule>(entity =>
            {
                entity.HasKey(e => e.Flightno)
                    .HasName("PRIMARY");

                entity.ToTable("flightschedule");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AirlineId, "airline_idx");

                entity.HasIndex(e => e.From, "from_idx");

                entity.HasIndex(e => e.To, "to_idx");

                entity.Property(e => e.Flightno)
                    .HasMaxLength(8)
                    .HasColumnName("flightno")
                    .IsFixedLength(true);

                entity.Property(e => e.AirlineId)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("airline_id");

                entity.Property(e => e.Arrival)
                    .HasColumnType("time")
                    .HasColumnName("arrival");

                entity.Property(e => e.Departure)
                    .HasColumnType("time")
                    .HasColumnName("departure");

                entity.Property(e => e.Friday)
                    .HasColumnName("friday")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.From)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("from");

                entity.Property(e => e.Monday)
                    .HasColumnName("monday")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Saturday)
                    .HasColumnName("saturday")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sunday)
                    .HasColumnName("sunday")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Thursday)
                    .HasColumnName("thursday")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.To)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("to");

                entity.Property(e => e.Tuesday)
                    .HasColumnName("tuesday")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Wednesday)
                    .HasColumnName("wednesday")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Flightschedules)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flightschedule_ibfk_3");

                entity.HasOne(d => d.FromNavigation)
                    .WithMany(p => p.FlightscheduleFromNavigations)
                    .HasForeignKey(d => d.From)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flightschedule_ibfk_1");

                entity.HasOne(d => d.ToNavigation)
                    .WithMany(p => p.FlightscheduleToNavigations)
                    .HasForeignKey(d => d.To)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flightschedule_ibfk_2");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("passenger");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Passportno, "pass_unq")
                    .IsUnique();

                entity.Property(e => e.PassengerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("passenger_id");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.Passportno)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("passportno")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Passengerdetail>(entity =>
            {
                entity.HasKey(e => e.PassengerId)
                    .HasName("PRIMARY");

                entity.ToTable("passengerdetails");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PassengerId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("passenger_id");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("country");

                entity.Property(e => e.Emailaddress)
                    .HasMaxLength(120)
                    .HasColumnName("emailaddress");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("street");

                entity.Property(e => e.Telephoneno)
                    .HasMaxLength(30)
                    .HasColumnName("telephoneno");

                entity.Property(e => e.Zip)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("zip");

                entity.HasOne(d => d.Passenger)
                    .WithOne(p => p.Passengerdetail)
                    .HasForeignKey<Passengerdetail>(d => d.PassengerId)
                    .HasConstraintName("passengerdetails_ibfk_1");
            });

            modelBuilder.Entity<Weatherdatum>(entity =>
            {
                entity.HasKey(e => new { e.LogDate, e.Time, e.Station })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("weatherdata");

                entity.HasComment("Flughafen DB by Stefan Pröll, Eva Zangerle, Wolfgang Gassler is licensed under CC BY 4.0. To view a copy of this license, visit https://creativecommons.org/licenses/by/4.0")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.LogDate)
                    .HasColumnType("date")
                    .HasColumnName("log_date");

                entity.Property(e => e.Time)
                    .HasColumnType("time")
                    .HasColumnName("time");

                entity.Property(e => e.Station)
                    .HasColumnType("int(11)")
                    .HasColumnName("station");

                entity.Property(e => e.Airpressure)
                    .HasPrecision(10, 2)
                    .HasColumnName("airpressure");

                entity.Property(e => e.Humidity)
                    .HasPrecision(4, 1)
                    .HasColumnName("humidity");

                entity.Property(e => e.Temp)
                    .HasPrecision(3, 1)
                    .HasColumnName("temp");

                entity.Property(e => e.Weather)
                    .HasColumnType("enum('Nebel-Schneefall','Schneefall','Regen','Regen-Schneefall','Nebel-Regen','Nebel-Regen-Gewitter','Gewitter','Nebel','Regen-Gewitter')")
                    .HasColumnName("weather");

                entity.Property(e => e.Wind)
                    .HasPrecision(5, 2)
                    .HasColumnName("wind");

                entity.Property(e => e.Winddirection)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("winddirection");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
