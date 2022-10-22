using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Website.racing
{
    public partial class racingContext : DbContext
    {
        public racingContext()
        {
        }

        public racingContext(DbContextOptions<racingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Headline> Headline { get; set; }
        public virtual DbSet<PlayoffSystems> PlayoffSystems { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Roster> Roster { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=192.168.4.59;user=root;database=racing;port=3306;pwd=Secretary-Reply-Alike-Librarian-7;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Config>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("config");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CheckTime)
                    .HasColumnName("checkTime")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InsertTime)
                    .HasColumnName("insertTime")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.DriverId)
                    .HasColumnName("driverID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.PrimaryColor)
                    .HasColumnName("primaryColor")
                    .HasMaxLength(7)
                    .HasDefaultValueSql("'''#fff'''");

                entity.Property(e => e.SecondaryColor)
                    .HasColumnName("secondaryColor")
                    .HasMaxLength(7)
                    .HasDefaultValueSql("'''#000'''");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.RaceId)
                    .HasName("raceID");

                entity.HasIndex(e => e.ScheduleId)
                    .HasName("scheduleID");

                entity.HasIndex(e => e.TrackId)
                    .HasName("trackID");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Cautions)
                    .HasColumnName("cautions")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RaceId)
                    .HasColumnName("raceID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RaceNum)
                    .HasColumnName("raceNum")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("scheduleID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.TrackId)
                    .HasColumnName("trackID")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_ibfk_1");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_ibfk_3");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_ibfk_2");
            });

            modelBuilder.Entity<Headline>(entity =>
            {
                entity.ToTable("headline");

                entity.HasIndex(e => e.DriverId)
                    .HasName("driverID");

                entity.Property(e => e.HeadlineId)
                    .HasColumnName("headlineID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DriverId)
                    .HasColumnName("driverID")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Headline)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("headline_ibfk_1");
            });

            modelBuilder.Entity<PlayoffSystems>(entity =>
            {
                entity.ToTable("playoffSystems");

                entity.Property(e => e.PlayoffSystemsId)
                    .HasColumnName("playoffSystemsId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(512)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.ToTable("race");

                entity.HasIndex(e => e.TrackId)
                    .HasName("trackID");

                entity.Property(e => e.RaceId)
                    .HasColumnName("raceID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Laps)
                    .HasColumnName("laps")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.TrackId)
                    .HasColumnName("trackID")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Race)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("race_ibfk_1");
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PRIMARY");

                entity.ToTable("results");

                entity.HasIndex(e => e.DriverId)
                    .HasName("driverID");

                entity.HasIndex(e => e.EventId)
                    .HasName("eventID");

                entity.Property(e => e.RowId)
                    .HasColumnName("rowID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DriverId)
                    .HasColumnName("driverID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Finish)
                    .HasColumnName("finish")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Laps)
                    .HasColumnName("laps")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Led)
                    .HasColumnName("led")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_ibfk_2");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_ibfk_1");
            });

            modelBuilder.Entity<Roster>(entity =>
            {
                entity.ToTable("roster");

                entity.HasIndex(e => e.DriverId)
                    .HasName("driverID");

                entity.HasIndex(e => e.ScheduleId)
                    .HasName("scheduleID");

                entity.Property(e => e.RosterId)
                    .HasColumnName("rosterID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.DriverId)
                    .HasColumnName("driverID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("scheduleID")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Roster)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roster_ibfk_2");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Roster)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roster_ibfk_1");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("scheduleID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PlayoffSystemId)
                    .HasColumnName("playoffSystemId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Series)
                    .IsRequired()
                    .HasColumnName("series")
                    .HasMaxLength(150);

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("track");

                entity.Property(e => e.TrackId)
                    .HasColumnName("trackID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(150);

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Layout)
                    .HasColumnName("layout")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(150);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
