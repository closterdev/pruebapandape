using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pandape.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedNameField4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExperiences_Candidates_CandidateIdCandidate",
                table: "CandidateExperiences");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExperiences_CandidateIdCandidate",
                table: "CandidateExperiences");

            migrationBuilder.DropColumn(
                name: "CandidateIdCandidate",
                table: "CandidateExperiences");

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

            migrationBuilder.AddColumn<int>(
                name: "CandidateIdCandidate",
                table: "CandidateExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperiences_CandidateIdCandidate",
                table: "CandidateExperiences",
                column: "CandidateIdCandidate");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExperiences_Candidates_CandidateIdCandidate",
                table: "CandidateExperiences",
                column: "CandidateIdCandidate",
                principalTable: "Candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
