using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pandape.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImplementForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperiences_IdCandidate",
                table: "CandidateExperiences",
                column: "IdCandidate");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExperiences_Candidates_IdCandidate",
                table: "CandidateExperiences",
                column: "IdCandidate",
                principalTable: "Candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExperiences_Candidates_IdCandidate",
                table: "CandidateExperiences");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExperiences_IdCandidate",
                table: "CandidateExperiences");
        }
    }
}
