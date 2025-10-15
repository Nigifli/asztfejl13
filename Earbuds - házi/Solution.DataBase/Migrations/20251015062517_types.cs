using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Database.Migrations
{
    /// <inheritdoc />
    public partial class types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @$"
            insert into
                [Type]
                ([Name])
            values
                ('Apple AirPods Pro'),
                ('Samsung Galaxy Buds2 Pro'),
                ('Sony WF-1000XM5'),
                ('Bose QuietComfort Earbuds II'),
                ('Jabra Elite 10'),
                ('Beats Fit Pro'),
                ('Anker Soundcore Liberty 4'),
                ('Shure SE215'),
                ('Sennheiser IE 200'),
                ('Moondrop Aria'),
                ('Campfire Audio Andromeda'),
                ('KZ ZSN Pro X'),
                ('Sony WF-C700N'),
                ('Bose QuietComfort Ultra Earbuds'),
                ('Apple AirPods Pro 2'),
                ('Beats Powerbeats Pro'),
                ('JBL Endurance Peak 3'),
                ('Jaybird Vista 2'),
                ('Anker Soundcore Sport X10'),
                ('HyperX Cloud Mix Buds'),
                ('Asus ROG Cetra II Core')
            ";

            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var query = $"truncate table [Type]";

            migrationBuilder.Sql(query);
        }
    }
}