using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Artalex.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditResponseAssignedTos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_response_assigned_tos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuditResponsePotentialGrounds",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_response_potential_grounds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuditResponseStatus",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    set_by_auditor = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    set_by_manager = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_response_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuditStatus",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuditTypes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_configs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    surname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    messenger = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    messenger_phone_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    additional_info = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    tenant_id = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    imo = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    last_audit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    next_audit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_auditor_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vessels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuditChapters",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    audit_type_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_chapters", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_chapters_audit_types_audit_type_id",
                        column: x => x.audit_type_id,
                        principalTable: "AuditTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_files", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_files_users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_user_logins_users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_user_tokens_users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    auditor_user_id = table.Column<int>(type: "integer", nullable: false),
                    audit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vessel_id = table.Column<long>(type: "bigint", nullable: false),
                    audit_status_id = table.Column<long>(type: "bigint", nullable: false),
                    audit_type_id = table.Column<long>(type: "bigint", nullable: false),
                    master_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    port_agent_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    port_agent_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    port_agent_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    embarkation_port = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    disembarkation_port = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audits", x => x.id);
                    table.ForeignKey(
                        name: "fk_audits_asp_net_users_auditor_id",
                        column: x => x.auditor_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audits_audit_status_audit_status_id",
                        column: x => x.audit_status_id,
                        principalTable: "AuditStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audits_audit_types_audit_type_id",
                        column: x => x.audit_type_id,
                        principalTable: "AuditTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audits_vessels_vessel_id",
                        column: x => x.vessel_id,
                        principalTable: "Vessels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VesselFiles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    file_path = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    vessel_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vessel_files", x => x.id);
                    table.ForeignKey(
                        name: "fk_vessel_files_vessels_vessel_id",
                        column: x => x.vessel_id,
                        principalTable: "Vessels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditQuestions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    audit_chapter_id = table.Column<long>(type: "bigint", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    explanation = table.Column<string>(type: "text", nullable: false),
                    reference_to = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_questions", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_questions_audit_chapters_audit_chapter_id",
                        column: x => x.audit_chapter_id,
                        principalTable: "AuditChapters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditManagerResponses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    audit_response_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    response_text = table.Column<string>(type: "text", nullable: false),
                    manager_id = table.Column<int>(type: "integer", nullable: false),
                    audit_id = table.Column<long>(type: "bigint", nullable: false),
                    audit_question_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_manager_responses", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_manager_responses_asp_net_users_manager_id",
                        column: x => x.manager_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audit_manager_responses_audit_questions_audit_question_id",
                        column: x => x.audit_question_id,
                        principalTable: "AuditQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audit_manager_responses_audits_audit_id",
                        column: x => x.audit_id,
                        principalTable: "Audits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditQuestionPotentialGrounds",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    audit_question_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_question_potential_grounds", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_question_potential_grounds_audit_questions_audit_question",
                        column: x => x.audit_question_id,
                        principalTable: "AuditQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditResponses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    audit_response_status_id = table.Column<long>(type: "bigint", nullable: false),
                    audit_response_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    audit_response_assigned_to_id = table.Column<long>(type: "bigint", nullable: false),
                    audit_response_potential_ground_id = table.Column<long>(type: "bigint", nullable: false),
                    audit_response_question_potential_ground_id = table.Column<long>(type: "bigint", nullable: true),
                    response_text = table.Column<string>(type: "text", nullable: false),
                    audit_id = table.Column<long>(type: "bigint", nullable: false),
                    audit_question_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_responses", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_responses_audit_question_potential_grounds_audit_question",
                        column: x => x.audit_response_question_potential_ground_id,
                        principalTable: "AuditQuestionPotentialGrounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audit_responses_audit_questions_audit_question_id",
                        column: x => x.audit_question_id,
                        principalTable: "AuditQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audit_responses_audit_response_assigned_tos_audit_response_assi",
                        column: x => x.audit_response_assigned_to_id,
                        principalTable: "AuditResponseAssignedTos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audit_responses_audit_response_potential_grounds_audit_respo",
                        column: x => x.audit_response_potential_ground_id,
                        principalTable: "AuditResponsePotentialGrounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audit_responses_audit_response_status_audit_response_status_",
                        column: x => x.audit_response_status_id,
                        principalTable: "AuditResponseStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_audit_responses_audits_audit_id",
                        column: x => x.audit_id,
                        principalTable: "Audits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditResponsePhotos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    audit_response_id = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    tenant_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_response_photos", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_response_photos_audit_responses_audit_response_id",
                        column: x => x.audit_response_id,
                        principalTable: "AuditResponses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_audit_chapters_audit_type_id",
                table: "AuditChapters",
                column: "audit_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_chapters_created_date",
                table: "AuditChapters",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_chapters_is_deleted",
                table: "AuditChapters",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_manager_responses_audit_id",
                table: "AuditManagerResponses",
                column: "audit_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_manager_responses_audit_question_id",
                table: "AuditManagerResponses",
                column: "audit_question_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_manager_responses_created_date",
                table: "AuditManagerResponses",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_manager_responses_is_deleted",
                table: "AuditManagerResponses",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_manager_responses_manager_id",
                table: "AuditManagerResponses",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_question_potential_grounds_audit_question_id",
                table: "AuditQuestionPotentialGrounds",
                column: "audit_question_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_question_potential_grounds_created_date",
                table: "AuditQuestionPotentialGrounds",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_question_potential_grounds_is_deleted",
                table: "AuditQuestionPotentialGrounds",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_questions_audit_chapter_id",
                table: "AuditQuestions",
                column: "audit_chapter_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_questions_created_date",
                table: "AuditQuestions",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_questions_is_deleted",
                table: "AuditQuestions",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_assigned_tos_created_date",
                table: "AuditResponseAssignedTos",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_assigned_tos_is_deleted",
                table: "AuditResponseAssignedTos",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_photos_audit_response_id",
                table: "AuditResponsePhotos",
                column: "audit_response_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_photos_created_date",
                table: "AuditResponsePhotos",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_photos_is_deleted",
                table: "AuditResponsePhotos",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_potential_grounds_created_date",
                table: "AuditResponsePotentialGrounds",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_potential_grounds_is_deleted",
                table: "AuditResponsePotentialGrounds",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_responses_audit_id",
                table: "AuditResponses",
                column: "audit_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_responses_audit_question_id",
                table: "AuditResponses",
                column: "audit_question_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_responses_audit_response_assigned_to_id",
                table: "AuditResponses",
                column: "audit_response_assigned_to_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_responses_audit_response_potential_ground_id",
                table: "AuditResponses",
                column: "audit_response_potential_ground_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_responses_audit_response_question_potential_ground_id",
                table: "AuditResponses",
                column: "audit_response_question_potential_ground_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_responses_audit_response_status_id",
                table: "AuditResponses",
                column: "audit_response_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_responses_created_date",
                table: "AuditResponses",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_responses_is_deleted",
                table: "AuditResponses",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_status_created_date",
                table: "AuditResponseStatus",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_response_status_is_deleted",
                table: "AuditResponseStatus",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audits_audit_status_id",
                table: "Audits",
                column: "audit_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_audits_audit_type_id",
                table: "Audits",
                column: "audit_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_audits_auditor_user_id",
                table: "Audits",
                column: "auditor_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_audits_created_date",
                table: "Audits",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audits_is_deleted",
                table: "Audits",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audits_vessel_id",
                table: "Audits",
                column: "vessel_id");

            migrationBuilder.CreateIndex(
                name: "ix_audit_status_created_date",
                table: "AuditStatus",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_status_is_deleted",
                table: "AuditStatus",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_audit_types_created_date",
                table: "AuditTypes",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_audit_types_is_deleted",
                table: "AuditTypes",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_configs_created_date",
                table: "Configs",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_configs_is_deleted",
                table: "Configs",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "RoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "UserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_files_created_date",
                table: "UserFiles",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_user_files_is_deleted",
                table: "UserFiles",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_user_files_user_id",
                table: "UserFiles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_logins_user_id",
                table: "UserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "UserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vessel_files_created_date",
                table: "VesselFiles",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_vessel_files_is_deleted",
                table: "VesselFiles",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_vessel_files_vessel_id",
                table: "VesselFiles",
                column: "vessel_id");

            migrationBuilder.CreateIndex(
                name: "ix_vessels_created_date",
                table: "Vessels",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "ix_vessels_is_deleted",
                table: "Vessels",
                column: "is_deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditManagerResponses");

            migrationBuilder.DropTable(
                name: "AuditResponsePhotos");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VesselFiles");

            migrationBuilder.DropTable(
                name: "AuditResponses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AuditQuestionPotentialGrounds");

            migrationBuilder.DropTable(
                name: "AuditResponseAssignedTos");

            migrationBuilder.DropTable(
                name: "AuditResponsePotentialGrounds");

            migrationBuilder.DropTable(
                name: "AuditResponseStatus");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "AuditQuestions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AuditStatus");

            migrationBuilder.DropTable(
                name: "Vessels");

            migrationBuilder.DropTable(
                name: "AuditChapters");

            migrationBuilder.DropTable(
                name: "AuditTypes");
        }
    }
}
