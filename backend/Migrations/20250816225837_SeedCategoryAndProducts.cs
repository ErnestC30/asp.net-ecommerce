using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_at", "description", "name", "slug", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer processing units", "CPUs", "cpus", null },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Motherboards", "motherboards", null },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GPUs", "gpus", null },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Random access memory", "RAM", "ram", null },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Monitors", "monitors", null }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "created_at", "description", "discount_price", "is_active", "name", "price", "quantity", "slug", "updated_at", "uuid" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. During operation television already citizen five. Happy and stand computer something thought that. Few either choice difficult.", null, true, "CPUs Address 5817", 394.64m, 16, null, null, new Guid("7c260558-7021-43d6-80ae-59badbf18b39") },
                    { 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Exist cold small receive. Hundred watch safe avoid story factor nearly.\nOften ability share training edge. Animal early southern commercial. City term set have whom. President camera mission no church conference among.", 168.09m, true, "CPUs West 9352", 226.74m, 43, null, null, new Guid("9fa1bacb-9838-4fd2-9cc6-d3fbf5f4fb28") },
                    { 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Approach identify probably. Performance share edge medical box large serious edge. Season thought center reason stay nearly himself.", 291.77m, true, "CPUs Price 4682", 508.32m, 40, null, null, new Guid("b140b8bf-929c-4598-afd7-c038f1d61e81") },
                    { 4L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Measure entire something whatever. Hair however much response. Recently point result gun few provide stand. Speak statement result early truth song.", null, true, "CPUs Set 8474", 1619.51m, 31, null, null, new Guid("f5f3a816-4e9f-4600-9d3b-05f07ff5cf10") },
                    { 5L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Full tree bed rise ten see grow. Glass including out identify thing laugh.", null, true, "CPUs Such 4853", 1286.11m, 1, null, null, new Guid("a69d6e96-4c77-409e-8c5d-7a59288ecd9c") },
                    { 6L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Live now interest fact control. Page upon increase word enough thousand investment.\nSenior possible available someone himself power.\nFood direction figure. Talk our dog important style model.", 312.54m, true, "CPUs Probably 4252", 419.47m, 14, null, null, new Guid("396da516-ad50-4d29-b777-acd1368ff205") },
                    { 7L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Type break already act. Scene direction many. Worry prove matter garden garden situation woman. Other interview hospital before tax between true.", null, true, "CPUs Soldier 4454", 1673.19m, 35, null, null, new Guid("99ff3aaf-ae46-439e-8aac-36087cf8a765") },
                    { 8L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Contain end follow area. Air set discuss.\nEnough writer another thought way.", null, true, "CPUs Policy 1187", 1083.14m, 47, null, null, new Guid("5621d2ec-8de3-49ff-97d1-99d7975e52d9") },
                    { 9L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Left air soon no. Indicate bring head laugh service though goal. Tough black fight right building man.", null, true, "CPUs Interesting 4379", 1722.39m, 9, null, null, new Guid("0be32ea6-4ef4-44aa-86a4-0c9e6087602d") },
                    { 10L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Throughout ago fall myself understand. Up while card air already certainly.", null, true, "CPUs Trouble 3069", 89.17m, 14, null, null, new Guid("e67282b5-6191-42c5-8389-28207fcd6f53") },
                    { 11L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Activity wall miss yet chance according tree yeah. Of today such market. Ago top but another international attack forget.\nEveryone party bank president. Above cup try trip always.", null, true, "CPUs On 9463", 609.15m, 31, null, null, new Guid("0ea60c87-0e74-4f05-94d2-60a3a81702a2") },
                    { 12L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Few future whole politics east. Act opportunity feeling wish more see. Father test what home want. Agent chance wife adult the.", 78.46m, true, "CPUs Trade 2141", 156.68m, 3, null, null, new Guid("5da471d6-def9-47d6-91f9-e4f639c0e984") },
                    { 13L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Choice fund power professional. Understand figure language strategy measure science. Around eight weight bag.\nSave idea building sport other. Prove particular similar most.", null, true, "CPUs So 7508", 454.27m, 24, null, null, new Guid("be586202-4aac-4550-b25e-099d9b503ef3") },
                    { 14L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. International be service cost follow indeed lead. Peace TV offer writer. Site end others I quickly smile. Both film western mention marriage rather.", null, true, "CPUs Maybe 9473", 374.31m, 28, null, null, new Guid("ffefce96-bc41-45bf-9d9e-f563648a9a0b") },
                    { 15L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Already bring discussion economy report interest. Language table first few two.", 902.16m, true, "CPUs Law 8004", 1213.04m, 1, null, null, new Guid("34ac763e-66c9-48ce-9ca5-8fd70d3fb013") },
                    { 16L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Myself write blue fill central anyone end. Watch like here particular. Clearly section fast car least fish language.", 1137.31m, true, "CPUs Film 8963", 1294.89m, 44, null, null, new Guid("be0abd5d-5d38-4560-8c97-8913eef833e8") },
                    { 17L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Significant between future research. Against money seem professor. Great need site action item.\nWhich government why wish. Represent save yet notice.\nVarious break decade surface himself green ahead.", null, true, "CPUs Without 7098", 285.06m, 22, null, null, new Guid("2d30dca3-a309-465e-b1b5-52f3d1bc326c") },
                    { 18L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. However nature by already rather focus. Community share remember policy enter team social. Type their should research.", 151.51m, true, "CPUs Quite 3994", 237.62m, 5, null, null, new Guid("c743adce-d661-467e-b8d9-adf9e1b3fbbd") },
                    { 19L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Place quality along deal event involve. Group rich eye example like manager treatment.", 696.13m, true, "CPUs Sometimes 7324", 1112.81m, 43, null, null, new Guid("68a290ce-1499-471e-964b-6c335bbc95f3") },
                    { 20L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Ball old ten. Success single seat participant relate.\nNone quickly pick smile student suffer weight. Art national me teacher relate traditional. Public time system food best western former.", null, true, "CPUs Both 4420", 1611.19m, 24, null, null, new Guid("00128cb5-3e9e-42a1-9f55-d61620bb338a") },
                    { 21L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Moment set health civil baby truth every. Race turn white process understand vote pressure.\nSon reach weight late range.", null, true, "CPUs Most 2330", 1897.34m, 41, null, null, new Guid("50eb53f0-b485-4bdf-80a5-2bda5e3653a2") },
                    { 22L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Season so hour pick rock. Experience score stand weight if not you. Effort team capital.", 278.8m, true, "CPUs Court 8776", 358.27m, 20, null, null, new Guid("b173953c-edd1-4870-bed2-b8144e34457c") },
                    { 23L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Less plant alone entire little. Standard hold hot everything ago choice. Admit job ask anything least practice where.\nBecome allow quite throw card into during. Factor trade watch suddenly ground wide.", 609.04m, true, "CPUs Cold 6289", 930.56m, 17, null, null, new Guid("d8037a0d-f842-422b-b857-d8581f558cc3") },
                    { 24L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. All even each safe true religious. Stuff until tell from trial.\nDrug these those rise. Evidence health magazine with. Operation perform marriage however vote law.", null, true, "CPUs News 1500", 1310.49m, 30, null, null, new Guid("81e2a78f-8e0e-4574-936d-e50eb749b81d") },
                    { 25L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Great different can system way. View avoid agency listen cultural. Inside same TV second design.\nElse increase daughter personal nature couple. Dog enter point board.", null, true, "CPUs Human 1538", 740.42m, 16, null, null, new Guid("7ec6bbe0-cec7-4913-a4a1-7f146d91f444") },
                    { 26L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Plant than actually old Mrs politics into. Such throw foreign face name green use. In enjoy student young six. Debate put second.\nRed natural race population section shake. Speak sport chance guess piece apply.", 1151.26m, true, "CPUs Arrive 4257", 1958.25m, 43, null, null, new Guid("97038745-e664-4bc7-905c-9416794d1af0") },
                    { 27L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Certain myself fund support think. Drop only summer increase practice face public seven. By him wish space third benefit.", null, true, "CPUs Business 5777", 436.04m, 18, null, null, new Guid("283d992d-fb50-40cf-a072-f22f323f8ff0") },
                    { 28L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Same change safe health happen. Onto hard whose one voice. Practice production agency poor region.\nUnit happen fine seem will office alone lot. Travel concern forget hospital. Knowledge inside statement local computer.", null, true, "CPUs Mission 1415", 1247.03m, 20, null, null, new Guid("052cfabe-c591-42ed-bbea-e2026f612e82") },
                    { 29L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. Image none effect to matter necessary project. Continue none section successful.\nMonth apply instead push. Minute past world city me current my.", 573.89m, true, "CPUs Control 6417", 1046.69m, 50, null, null, new Guid("690847e9-a0fd-4f98-b951-2da8cb2dea19") },
                    { 30L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This cpus is designed for high performance in computing. The space development oil bar add rule. Politics game despite clear every.\nBall run physical born fast. A mind wind begin.", null, true, "CPUs Smile 6834", 1933.27m, 43, null, null, new Guid("e2ac8e1e-8f90-4f24-8880-3c762fe1747e") },
                    { 31L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Fear family building positive artist open. Green wall class son create positive best. Organization fear growth final worker.\nLot crime fly house prevent class. Career order effort note owner center. Other worker realize bar along guess Mr.", null, true, "Motherboards Spend 6692", 1748.79m, 27, null, null, new Guid("c4cd8465-a6d7-410c-88f2-8782bfff6816") },
                    { 32L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Describe world card worry brother. Magazine social describe may.\nCharge whose feel though my finish stage think. Society discuss read research authority heavy.\nJob enough those wife. Watch baby store opportunity most boy none agency.", null, true, "Motherboards Prove 7158", 1236.96m, 48, null, null, new Guid("6decc845-5dcb-4b16-ab08-821fc960aae8") },
                    { 33L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Build mother material bit. Call blood operation test. Interest building natural fast better skin.\nEverything husband manager loss that picture. Until student bag exist minute summer.", null, true, "Motherboards Perhaps 2674", 628.5m, 42, null, null, new Guid("08abb241-f377-450d-b09c-8d6b9077c10e") },
                    { 34L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Plant hospital natural ten stay. Likely camera gas energy blood I job month. Song range specific manage.", 634.81m, true, "Motherboards Company 4640", 709.87m, 6, null, null, new Guid("a3e6935d-6e24-4e11-9aa3-7f8027d1cc9d") },
                    { 35L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Campaign film necessary task daughter those newspaper. Skin explain even call.", 862.98m, true, "Motherboards Agent 3404", 1220.12m, 14, null, null, new Guid("1d3cdee1-3b6a-4aa9-8532-3dfa11f4a2be") },
                    { 36L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Opportunity probably glass I purpose response. Particularly or religious debate rest.\nAmong around position nor design strong body watch. Society soldier brother policy.", null, true, "Motherboards Because 9031", 1413.25m, 17, null, null, new Guid("6de5e4eb-8c99-4a08-979f-3f9ad7b4e726") },
                    { 37L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Stage great pretty smile. Serve technology around audience official war your. When rate learn sure.", null, true, "Motherboards Involve 6172", 53.79m, 36, null, null, new Guid("d2e82514-0e01-4fb7-854b-5259dc451985") },
                    { 38L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. World not issue factor what difference. History customer represent paper always. Member task month particularly.", null, true, "Motherboards For 1311", 749.99m, 17, null, null, new Guid("6b1d72f7-4a05-4a7b-bf97-58c73193c3bd") },
                    { 39L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Structure practice agree me according exactly size.\nProtect check result pay big. Gas market face ago risk group.", null, true, "Motherboards Current 4152", 791.19m, 21, null, null, new Guid("92fba02a-6f21-4e3b-bea7-2c5cc02bf7a6") },
                    { 40L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Simple including girl police investment. Professional board couple mission offer. Tree beat war.", null, true, "Motherboards Recognize 6698", 1776.42m, 25, null, null, new Guid("130f6b9f-ac14-4f65-be19-523922854bc7") },
                    { 41L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Effort white color thought daughter consider. Cup act training drive former hotel. Follow mean entire feel. Ok more dinner choice.", 189.76m, true, "Motherboards Likely 7574", 368.08m, 19, null, null, new Guid("6d20466d-9515-4cc2-8c78-85486c0178cc") },
                    { 42L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Whatever edge return positive him customer. Husband memory perhaps. Actually stock north receive.\nNation understand sport main figure. It position memory identify group. Issue deep personal if.", null, true, "Motherboards Dog 8060", 1664.92m, 36, null, null, new Guid("5e8a16fb-c7a7-40be-8881-6084cb312939") },
                    { 43L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Visit people fill after together. Room form but involve wonder all age.\nFinal evening change establish list house million yes. Perhaps hear easy you. Might add all talk.", null, true, "Motherboards Paper 5012", 1666.32m, 32, null, null, new Guid("cd3ff0cf-0dc1-4e30-a8d7-4b8634314f80") },
                    { 44L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. He adult throw late board source. Owner address capital ahead fire part prepare.", null, true, "Motherboards Machine 2642", 823.84m, 4, null, null, new Guid("d1a558cf-f2ba-4ff9-8eba-6a79126a8645") },
                    { 45L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Former difference prepare too. Study save term fish determine.", null, true, "Motherboards Report 7187", 86.97m, 9, null, null, new Guid("1b27631f-d795-46b3-aae4-522ba133b4c0") },
                    { 46L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. True expert either. Cultural here customer result gun rise.\nField production set marriage certainly glass bill create. Camera if expect budget.", 993.31m, true, "Motherboards Dark 5384", 1574.57m, 3, null, null, new Guid("689c1107-e7af-42ba-94d4-8601d810f541") },
                    { 47L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. South offer black price gun simply work.\nBaby nearly reduce up head. Little professor ever good detail someone. View amount sign half.", null, true, "Motherboards Result 1991", 1431.08m, 22, null, null, new Guid("b391c9d5-ddec-450f-8252-065ba0e4707a") },
                    { 48L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Glass resource smile couple rate yourself. Need know only month. Sing strategy face quality themselves treat mission stage.", null, true, "Motherboards Marriage 4956", 1348.9m, 29, null, null, new Guid("88148a02-5a04-41c3-b924-f77d295d0c5e") },
                    { 49L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Right sign decade word kitchen. Alone cell police provide challenge big fact whom.\nSome management five especially through artist. Significant both road nothing instead president ground. Thank good present.", null, true, "Motherboards Discuss 6549", 1927.54m, 25, null, null, new Guid("13958491-9837-42e2-bf62-9e638c54841f") },
                    { 50L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. View car point these center. Sport many sure answer bag.\nStage interview pull fall this part. Glass culture may might son college yet.", 1355.04m, true, "Motherboards Hair 7074", 1945.35m, 33, null, null, new Guid("44c15095-2d67-470b-ae29-dbed819fb063") },
                    { 51L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Maintain sense now public could so truth. Eat a despite race should. Under watch president could million move.", null, true, "Motherboards Energy 7203", 666.9m, 38, null, null, new Guid("bd6efc58-1fe9-45be-a268-e3b2975a678f") },
                    { 52L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. A citizen care business economy carry. Similar national debate audience.\nFloor deal second with. Within stand culture home.", null, true, "Motherboards Conference 2783", 588.61m, 32, null, null, new Guid("6d4f07d8-19a6-4685-add8-59c50579d3e3") },
                    { 53L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Movement free science three receive. Born citizen practice west despite physical from just. Seven when final difference word him.", null, true, "Motherboards Value 3579", 1527.98m, 5, null, null, new Guid("96cba97e-aee5-4116-9a6d-5f8edeaf2d54") },
                    { 54L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Own however cold rock outside. Into available street talk head style avoid.\nInterest west assume last environment cup. Life wife big ground. Our accept where listen.", null, true, "Motherboards Brother 8355", 800.78m, 11, null, null, new Guid("c2853296-4e8b-4c4b-98ec-5e9bf836834b") },
                    { 55L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Same cup test cover. Later world administration begin. List audience product use picture standard.\nFuture they fill smile all system.", 881.12m, true, "Motherboards Reflect 1400", 1260.26m, 46, null, null, new Guid("fdb1fe21-8dbd-4b08-8f15-a127e4caa8d1") },
                    { 56L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Degree paper list song. Measure break trade. Gas land site for between.\nDifference task suffer mission write my.\nColor over onto say. Build my young lawyer.", null, true, "Motherboards Despite 3442", 303.85m, 17, null, null, new Guid("58c18300-0921-4421-88ce-efbd0c46a308") },
                    { 57L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Treatment risk world agent hospital. Congress friend else three whatever herself. Case hand let threat man record.\nType young among audience. Appear raise example gas open data health. Machine enter management.", null, true, "Motherboards Once 9839", 190.67m, 21, null, null, new Guid("3cb63921-e2e2-450c-af56-88d4fc474318") },
                    { 58L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Affect skill decide without world. Think why big of way level way. Attention cell fast friend.", null, true, "Motherboards Recently 4069", 1970.45m, 1, null, null, new Guid("b6797826-a556-4c0d-bf42-2068433f7026") },
                    { 59L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Guy teacher voice. Well candidate country even soon outside.", null, true, "Motherboards Clear 8734", 511.3m, 26, null, null, new Guid("488d3f9a-c101-49a4-a287-f1b82eadc99f") },
                    { 60L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This motherboards is designed for high performance in computing. Keep market expect and everybody. Mention somebody letter subject employee thing he. Top entire current operation.", null, true, "Motherboards A 1824", 83.74m, 36, null, null, new Guid("49566aba-456b-4f47-99af-0e56f7bad507") },
                    { 61L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Trouble sit about claim. Can own our beautiful.", null, true, "GPUs Especially 9206", 1149.03m, 20, null, null, new Guid("da1ce236-dacb-4c8a-8e60-f9b06daf6275") },
                    { 62L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. World area north particularly. Can middle soon travel get southern remain. Become base represent age.", null, true, "GPUs Five 8942", 1101.9m, 3, null, null, new Guid("4e3f9abe-5c87-478f-8913-356004e2fe8e") },
                    { 63L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. White image time himself involve still. Same range art source her put herself pattern. Young trial carry too.", 861.2m, true, "GPUs These 3686", 1287.21m, 36, null, null, new Guid("7d45ba35-2896-4330-9c47-7d1832e17c1e") },
                    { 64L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Market dark range open must oil pattern student. Which recently word them.\nHome day view plant challenge. Happen always letter must.\nCountry career cover though.\nFormer number bring nor.", null, true, "GPUs Social 2045", 1436.51m, 48, null, null, new Guid("b43c55a4-4bdc-471b-a979-3c9698fef5ea") },
                    { 65L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Include might morning generation country today lot. Technology buy drug relate police drug call.", null, true, "GPUs Forget 3918", 1065.15m, 1, null, null, new Guid("72c81366-a831-4772-98f7-f687b098b1ec") },
                    { 66L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Blue concern name century feel pretty. Start letter marriage piece.\nBrother positive collection name. Those care performance candidate nor nice lose.", 636.45m, true, "GPUs Important 9009", 843.73m, 13, null, null, new Guid("36bd4de0-b95e-4e3a-850c-a14e0d3d8e2f") },
                    { 67L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Character eight father painting sign every. Fill car voice deal.", null, true, "GPUs Why 9895", 1076.62m, 1, null, null, new Guid("6318edf7-4483-4107-8017-f7fe718f9a30") },
                    { 68L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Sing feeling reason while drug. East contain field during fill.\nCare door modern reach music get. Activity campaign this minute. Arm picture generation.\nPresident political scene head lot media help.", null, true, "GPUs Matter 2316", 905.18m, 11, null, null, new Guid("6a709d4e-a376-42a2-9141-52dd560789d4") },
                    { 69L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Yeah appear game else culture have since question. Certainly certain dinner let.", null, true, "GPUs Pm 4085", 1121.38m, 13, null, null, new Guid("58579cf1-5518-419c-9f8e-df75a82a2af1") },
                    { 70L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Each region drive little increase these network. Education left into activity. Month report realize onto attorney hospital walk.", null, true, "GPUs Myself 1834", 658.42m, 8, null, null, new Guid("7c540038-ba7d-474e-973c-70316b3596d0") },
                    { 71L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Join cause tell food likely though. Must total PM material. Generation system key officer sometimes contain customer.\nPolice election reflect friend herself politics smile.", null, true, "GPUs Teacher 8899", 526.1m, 19, null, null, new Guid("55dcb438-16cc-4f6a-9155-8758e59ca5a1") },
                    { 72L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Front behind cause attention across. Play door wide heart.\nStudy state effect continue position what rate. Southern professor head next rock oil.\nFast response force last former. Style special book.", null, true, "GPUs Wonder 5600", 1378.49m, 3, null, null, new Guid("6b830c69-f871-4559-989c-9a45700f4c86") },
                    { 73L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Task example exactly nearly hear. Try bring himself traditional century.\nBeyond especially these program.", 341.36m, true, "GPUs Clearly 7720", 491.25m, 17, null, null, new Guid("2eb3370c-297b-4b0f-a03b-91381c95ff7a") },
                    { 74L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Involve bank turn window where. Ahead save expect possible light air. Little gun easy glass city coach.\nTrade animal hundred see particular. Town physical instead fish.", null, true, "GPUs Use 2374", 224.96m, 35, null, null, new Guid("ac2b4a1d-22e7-42b8-b0f5-d0faa62e1c6c") },
                    { 75L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Life task much wide boy college family.", null, true, "GPUs Television 7454", 339.44m, 41, null, null, new Guid("1930f714-7fc0-484e-8052-bfc50e26c654") },
                    { 76L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Whom president quite where vote. Discussion tough certainly life.\nDevelopment wonder fine yes. Note answer car involve. Or federal unit table career.", null, true, "GPUs Myself 4000", 1632.37m, 28, null, null, new Guid("62acee60-113e-4085-aa51-d2ad81699725") },
                    { 77L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Month firm never always war cell. Week rich lot visit capital once energy.", null, true, "GPUs Industry 1391", 1476.82m, 12, null, null, new Guid("72498af3-6cd9-4726-b18f-dd273c99d624") },
                    { 78L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Fill economic pull enough natural cell tough. Wait green whatever environmental join.\nBig hospital within soon. Product raise strategy term. Actually soon return reach true pass.", null, true, "GPUs Such 4866", 1079.34m, 42, null, null, new Guid("f1ff6c87-846e-4a80-b980-05712b67b969") },
                    { 79L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Option inside standard seven type term follow sense. Itself whole view quickly.\nAssume side ready rule. Film rule black explain. Out on gas white wall on home now.", 151.0m, true, "GPUs Cost 6148", 192.55m, 1, null, null, new Guid("3d9dc234-2344-42ea-badc-75862e85855e") },
                    { 80L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Finally blood consumer often teach finish. Investment they personal sea quality source coach. Rule get if understand listen.", null, true, "GPUs Military 6452", 1999.09m, 4, null, null, new Guid("970f8790-5f8e-4815-a8fc-0df65a10f50f") },
                    { 81L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Recently executive down end thousand. Expect budget each draw song skin.\nDoctor worry result follow here wonder remain. Concern final but. Ability police action baby.", 624.44m, true, "GPUs Detail 5640", 917.32m, 19, null, null, new Guid("3f91e1ea-2fbe-4427-bea8-065246bd0c16") },
                    { 82L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Charge walk parent. Find like next oil agency reduce. Fire today responsibility data example floor data before.", 581.73m, true, "GPUs Important 5671", 1132.88m, 45, null, null, new Guid("726d2b4e-1e8c-4695-848b-94f2723a197d") },
                    { 83L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Garden three chair worker decision. Case economy ask ahead guy.\nCold feel save including south type.\nEver try poor address other. Power interesting assume property to attack.", null, true, "GPUs Dinner 1607", 1709.83m, 20, null, null, new Guid("1e7b2e93-2a87-4b7e-9b84-8eca8e6cf367") },
                    { 84L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Article tree four international time away lay. Gas remain position different. Technology black administration visit moment treatment kitchen.", 624.79m, true, "GPUs Represent 9787", 869.87m, 6, null, null, new Guid("493bf62e-dbfe-4371-93e3-3bf17de388aa") },
                    { 85L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Day cut father subject whatever smile then. Now nothing public certainly. Decision field though note western half.\nSister top student on unit. Investment once yeah. Central as dinner matter student.", null, true, "GPUs Could 1212", 1865.68m, 41, null, null, new Guid("df72c4d7-deb2-4216-8a3b-4c28b50e0113") },
                    { 86L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Mrs itself always throw.\nStyle state tonight fight my character. Firm skin already simple.", null, true, "GPUs Myself 2502", 1348.21m, 14, null, null, new Guid("6e2e501e-fcd9-4dde-985f-e3c73ee2f469") },
                    { 87L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Special customer live first ago support court. Camera life show seek either. Environment raise address reduce news small.\nLearn ten hold perform person. Rest house simply interview town fine this. Others claim whether.", null, true, "GPUs Feel 3023", 1752.32m, 41, null, null, new Guid("04db4e40-c2a5-46ee-af3c-0de868cf5542") },
                    { 88L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Exist course sort imagine. Eat site world offer thing campaign. Health write represent expert water.\nStill five step.", null, true, "GPUs Thought 6603", 1610.18m, 1, null, null, new Guid("a93399c1-32a5-4682-b3f6-27c653a9cfd7") },
                    { 89L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Writer cold down film industry white. Girl herself her compare clearly realize. Claim wish usually him sell. Hotel understand collection little.", null, true, "GPUs Mean 2970", 610.06m, 34, null, null, new Guid("8a75e481-051d-4ff2-b85e-8d161191f307") },
                    { 90L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This gpus is designed for high performance in computing. Something rock tell activity then. Guess mission mention kitchen surface middle. Mr article work friend economic soldier couple paper.\nPolicy order life seat thank national many remain. Alone may mean wind car arrive water like.", null, true, "GPUs Century 4405", 408.99m, 5, null, null, new Guid("249a31cb-23a9-4d2c-b9b2-e4acb59e0c9b") },
                    { 91L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Sense it as thank leader.\nManager natural catch the she thank bit. Level someone run according certain subject event.", null, true, "RAM Despite 5869", 73.98m, 10, null, null, new Guid("16726b93-9fce-486d-ad20-a8faabafda95") },
                    { 92L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Firm firm citizen. Back road senior sure myself.\nHealth close drive trial keep among. Sport cover course in do class food. Like fly grow choose brother.", null, true, "RAM Summer 6943", 1576.72m, 23, null, null, new Guid("b925335e-a330-4515-8727-a68fefc9f96d") },
                    { 93L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. The street war article board policy. Seven top it different daughter raise. This on energy worker.", null, true, "RAM Action 6877", 1705.56m, 42, null, null, new Guid("44b7e6d7-eea8-43ff-942c-d6ba43d8bde4") },
                    { 94L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Determine of throughout little. Republican light man itself affect direction management off.", null, true, "RAM Off 9395", 1798.5m, 10, null, null, new Guid("7723c434-c917-4d0b-8344-a4304d958423") },
                    { 95L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Myself approach set technology. Baby specific brother able fund. Stand oil book benefit performance argue.", null, true, "RAM Push 9120", 433.33m, 28, null, null, new Guid("497992b0-7fdf-4aba-b004-1e77e46153de") },
                    { 96L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Any film happy nothing laugh me other. Consumer hold discover hear film summer.", null, true, "RAM Event 6331", 910.65m, 18, null, null, new Guid("059c705b-3ce5-4fa6-8839-4ad092ecaed9") },
                    { 97L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Democratic forget reason modern one. Line they me. Blue may military else.\nLay democratic raise world wonder.", null, true, "RAM Memory 3340", 1045.54m, 31, null, null, new Guid("6a84ea6c-b85a-4b96-b2d2-7b46a2746f3d") },
                    { 98L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Rest light establish can north. Keep soldier hope general. Wrong music either mean. New garden quite cultural scene and cup series.", null, true, "RAM They 9665", 496.58m, 6, null, null, new Guid("2d34debe-383e-494a-9e94-36ebbbcb8889") },
                    { 99L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Great probably race event realize region test peace. Firm skin near which executive however visit.", 418.96m, true, "RAM Amount 6875", 684.96m, 17, null, null, new Guid("0dc633df-19e4-4894-9f56-7208ecfad4a6") },
                    { 100L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Every of seek prove draw. Little culture real yourself offer simply. Husband child seat. Military me relate same owner deal.", null, true, "RAM Loss 4627", 1043.33m, 45, null, null, new Guid("e7d879e3-9f76-446d-a654-8529e24050df") },
                    { 101L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. When kind evening reveal. Bank already rich politics design. Business ten not market whether short.", 967.31m, true, "RAM Go 5378", 1202.3m, 26, null, null, new Guid("4a59f47d-ba4d-480e-b336-d89d7640bae0") },
                    { 102L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. How good so medical high morning. So place candidate although her.\nItself knowledge live play provide. Grow PM bring site put especially.\nTheory support now. Put message point him.", 135.46m, true, "RAM Water 5086", 219.81m, 30, null, null, new Guid("2bbbb17a-0e60-44fd-b348-09b17faeb366") },
                    { 103L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Weight bank coach opportunity future open.\nThere action treatment poor stop. Manager activity might personal. She discover worry indicate night rule.", null, true, "RAM Bring 5495", 1611.09m, 48, null, null, new Guid("5bc5ae88-d7f1-4f20-be21-741da7caa353") },
                    { 104L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Bring yourself first within bill true last participant. Enough that able traditional charge side. Clearly tax across too open technology beautiful.\nDo remain finish nor some.", null, true, "RAM Our 1039", 1914.76m, 28, null, null, new Guid("dcb10452-ed30-44b0-8004-8a07907eee93") },
                    { 105L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Red air cut break man. Standard brother avoid. Painting possible time.\nWill development admit here able begin. Lay here short. Change begin guess various.", 1397.51m, true, "RAM Performance 1850", 1566.72m, 44, null, null, new Guid("800a4853-c165-4aae-ad57-4a30bca59f78") },
                    { 106L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Understand floor each whom arm raise. Beyond friend attack throw. Affect money old land.", null, true, "RAM Wish 1944", 1765.9m, 2, null, null, new Guid("0a4639a3-384e-4b21-b55d-2ca3195902de") },
                    { 107L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Mean career direction drug. Radio couple series better clear. Company condition edge respond office win road.\nLittle together whatever kind last now. Enjoy year training stay.", null, true, "RAM Coach 6073", 512.77m, 35, null, null, new Guid("2e0fce89-2e1b-4b10-83c1-b5bbc9338d5c") },
                    { 108L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Yeah meet tell area song history anyone. Safe third owner large international the.\nCompare past prove bed enjoy range stop season.", null, true, "RAM Order 1577", 1519.4m, 34, null, null, new Guid("4c847a65-c1dc-4fad-8d6b-44fd117ab453") },
                    { 109L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Activity summer culture local sell. Once think our measure.\nWhite defense must detail professor.\nDark speak article beat without. During subject read bed together threat probably.", null, true, "RAM Total 7366", 1251.58m, 33, null, null, new Guid("08882a37-1540-4b36-8469-639275bba2d5") },
                    { 110L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Reach authority say example significant. Onto mind little or.", null, true, "RAM Agree 3887", 610.23m, 18, null, null, new Guid("6de8c19c-5fb6-4a6f-a85e-0fd0d94b1f61") },
                    { 111L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Might form year establish rate than. Tell they thus player away. Court ability pressure civil guy reality.\nThere seat meeting later treatment. Range professor season quality rise. Only business growth already.", 180.57m, true, "RAM Large 3163", 252.28m, 9, null, null, new Guid("996014f4-d4c9-4eaa-8aaf-197a341955cc") },
                    { 112L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Here but scientist argue themselves. Trade floor poor either opportunity let animal.", 1439.76m, true, "RAM Image 3503", 1647.92m, 14, null, null, new Guid("9e80f748-b594-445f-a02b-903c4f93d0a3") },
                    { 113L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Help bed on rise dog left cover. Finish always start author moment tree argue could. Not remain with these than major.\nAlso behind none hear partner job. Blood city upon machine this.", null, true, "RAM Film 3408", 1397.55m, 46, null, null, new Guid("7dc2ef11-ceb5-4997-9a44-2870ec0f4e1e") },
                    { 114L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Machine physical eight party account inside. Poor increase because finally four husband from. Smile soon thank maintain positive response.", 177.07m, true, "RAM So 5297", 342.18m, 30, null, null, new Guid("299deaf6-ce0c-456c-be74-c65504ba2a9e") },
                    { 115L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Range hotel dream easy middle customer. White turn system. They poor personal peace investment prepare.\nUp who environmental far mother. Must deep item never offer industry.", null, true, "RAM Direction 2069", 1017.67m, 28, null, null, new Guid("c7f74102-d308-4fdc-864f-1b3f1b4961b4") },
                    { 116L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. There sing even though. Some activity city reduce.\nRise whole activity actually. Hour college benefit time night thing agreement. Worry study firm quickly back opportunity surface.", null, true, "RAM Wear 6630", 1354.94m, 47, null, null, new Guid("4cbf21bd-e2b2-43a6-a177-08f353d5a887") },
                    { 117L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Anyone third family letter. Seven improve sort. Interesting instead knowledge tend sometimes operation.", null, true, "RAM Work 9609", 1518.32m, 9, null, null, new Guid("db787c42-433f-4afd-ad6e-1b733ccf9a00") },
                    { 118L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Hit test interest somebody forget word. Everybody environment best treat wrong war tree. Low force report recognize.", null, true, "RAM Authority 8882", 766.72m, 2, null, null, new Guid("5ad01c52-b262-4697-a8d9-a882f3bd8c6d") },
                    { 119L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Family rule task nation kid hard president. Amount produce onto style to.\nWhite production exactly government reflect strategy. Near likely language third according actually. Million find process daughter last.", 1462.14m, true, "RAM Deal 6475", 1812.76m, 8, null, null, new Guid("c7ca7ccd-2ee6-4a70-bb52-0218bdfb11fc") },
                    { 120L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This ram is designed for high performance in computing. Goal rest can team day knowledge challenge. Process order mind middle computer ahead. Discussion think similar enough.", null, true, "RAM Understand 9502", 1921.25m, 39, null, null, new Guid("ac691de8-98a2-4170-99a1-39b89c650e87") },
                    { 121L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Chance eight practice poor environmental board.\nRecent mention poor. Office become return commercial future some.\nTeam simple owner course whole indeed serve. Record clear leg throw issue he.\nClear bed product reflect.", null, true, "Monitors Tough 1951", 94.13m, 25, null, null, new Guid("76a023a5-225e-436d-b3d0-10c9c74d6943") },
                    { 122L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Degree wonder bank explain. Special mention listen.", 182.14m, true, "Monitors Painting 2750", 272.94m, 49, null, null, new Guid("a9d64774-7e4c-4bdb-9e6d-198cb50c5f08") },
                    { 123L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Choice bring lead young live stop executive. Back she onto. Success authority yet official.", null, true, "Monitors Finish 3837", 113.16m, 11, null, null, new Guid("e11bc9e9-087d-46f8-948c-e0138da1b1d1") },
                    { 124L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Against wind eat machine whose continue carry. Society necessary strategy their economy fast agreement. Into time quickly get its.\nNotice leave job old. Support trade already four.", null, true, "Monitors Movement 7848", 931.18m, 29, null, null, new Guid("ca093438-cb66-4d1a-bc9e-c677526fe48f") },
                    { 125L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Public side safe mean task. Environmental camera somebody water.\nTrip she consider go writer. Alone throw fire entire body. Option company table billion alone.", null, true, "Monitors Piece 1349", 1019.16m, 41, null, null, new Guid("1bfbb22d-fa28-49fe-8af7-6e1ae9d69173") },
                    { 126L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Air religious third could stuff ten. Congress level father relate unit specific.\nFly anything but growth ok.", null, true, "Monitors Democratic 2858", 901.2m, 15, null, null, new Guid("7f8e63c0-5829-4d98-9b3c-f1b9e00df8de") },
                    { 127L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Hard available foot whatever safe the. Day simple current week field blood ok. Growth detail back smile.", 85.55m, true, "Monitors But 1236", 146.52m, 35, null, null, new Guid("04529d11-a92a-49d6-bfe7-3bd6184854a7") },
                    { 128L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Test however follow. Enter because even.", 1509.83m, true, "Monitors Magazine 3604", 1703.05m, 16, null, null, new Guid("201bfc27-8e02-4713-b7bc-50a004a7d031") },
                    { 129L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Plan trouble material quickly dog. Trip door beyond. Fine bar player thing ready child expert.", 997.01m, true, "Monitors Stop 3731", 1529.52m, 44, null, null, new Guid("70b36aa0-9b23-452f-91f4-43915c4f166d") },
                    { 130L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Pay line hand young other Republican. Trade billion better north. Case walk research conference upon.", 562.99m, true, "Monitors Campaign 6191", 649.68m, 1, null, null, new Guid("f67d6618-fb6e-4bde-9d54-9d9d762efff7") },
                    { 131L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Draw sound go clear former season image. Place TV whose both next sit.", 811.47m, true, "Monitors Lead 7361", 1407.26m, 22, null, null, new Guid("744af988-8ac6-4d32-9d2b-c04bf51fe41b") },
                    { 132L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Why too hard standard. Drug spring age so west become ground religious.\nOffice kind whom gun senior. Kind phone to yard senior reason none.", 643.68m, true, "Monitors Near 1549", 997.63m, 24, null, null, new Guid("95551603-57ce-4ade-a7f9-dd2fbde7f20c") },
                    { 133L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. About certain pay treat magazine recently single. Expect plant now cup key.\nAbove along perhaps more. Parent down choice.\nFast social agree paper left camera cause where.", 239.64m, true, "Monitors Hotel 5827", 274.8m, 30, null, null, new Guid("3bc05221-71a3-4eb2-af16-3b6280fc7ebf") },
                    { 134L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Player school child long. State nation adult pass do fight ground.\nDown successful drop western paper. Quality field somebody market report know. Speak girl radio officer say everyone. Actually deep race.", null, true, "Monitors Get 9272", 1420.11m, 44, null, null, new Guid("5b509654-a62b-48c6-8149-72a152c1bd18") },
                    { 135L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Reflect require accept measure house subject recently. Career quality partner trip film look blood. Car pull late cut stuff participant cause.", 725.79m, true, "Monitors Type 2098", 1348.83m, 35, null, null, new Guid("4c28e3ba-1e2a-4ba9-b5c5-fbd07cf9aa85") },
                    { 136L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Nearly hot executive like. Across around give push order.\nFall civil teacher every eight that real. Talk positive into carry because it central able.", 653.39m, true, "Monitors Dream 8196", 773.66m, 3, null, null, new Guid("543e9718-a7fd-445c-9a05-824a22051fbe") },
                    { 137L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Heavy sea face girl however common. Hold play claim consider teach manage protect area. Best skin pay under century she heavy.", null, true, "Monitors Wonder 5409", 1935.27m, 44, null, null, new Guid("2d4f049a-7a41-46ce-893a-aef82fea9e80") },
                    { 138L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Law many protect class. Without join without identify capital.\nClear since study decade. Important measure through activity foot true card.", null, true, "Monitors Suffer 2979", 1727.59m, 29, null, null, new Guid("e1184a97-1d22-4c74-b6b3-5e9f4d035e9a") },
                    { 139L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Performance doctor book herself author. Up yard many side any relationship moment degree.", 659.31m, true, "Monitors Least 8507", 836.21m, 22, null, null, new Guid("88b3f8fd-e1d1-4b8f-88bf-4be2a8ce0823") },
                    { 140L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Red among student serious live throw might discover. Away central evidence health. Serve live individual evening third ability.\nShare sell wind appear answer. Method conference fight science matter end leg.", null, true, "Monitors Never 5945", 1808.23m, 45, null, null, new Guid("1559d9eb-2f91-4c6c-8568-2e48dcb42e6b") },
                    { 141L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. He establish career think alone camera husband. Man however suggest. Go summer new.\nDevelopment matter various contain. Follow loss quality eye eye debate create.\nJob action defense learn. Source activity house.", null, true, "Monitors Sport 6616", 803.53m, 25, null, null, new Guid("cd3ec2b8-ab7d-4cbb-86b3-5dc2689255a0") },
                    { 142L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Sport any difference election job task speak. Heavy toward compare whatever weight very still. Social build such every wide state cause.\nThree care arm represent whom suggest any. Strategy moment treat wear. Tv last current physical those too.", null, true, "Monitors Money 2618", 1202.27m, 39, null, null, new Guid("4eafae8b-4c5a-4d75-a727-9f6a02703faa") },
                    { 143L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Paper pretty seek recognize surface light. Boy create item under hear now. Wall member issue off necessary future two.", null, true, "Monitors Laugh 6208", 580.33m, 7, null, null, new Guid("bd6580aa-77dd-4dea-8621-d6bc7d1a8bc4") },
                    { 144L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Continue nature rise. Son claim trouble. Never over American food.\nRadio recent event strategy. Discussion woman professional brother item your. Reflect push pattern explain own sound.", null, true, "Monitors Project 3723", 1165.41m, 27, null, null, new Guid("b71304fb-8959-49e9-9e15-fb081da8b471") },
                    { 145L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Author safe style tell kid want hit. Parent general ball successful oil middle method. Eight draw find take.\nMarket allow sense majority manage herself. Former better begin himself. Recently result picture truth owner skin public.", null, true, "Monitors Relate 2708", 357.09m, 9, null, null, new Guid("849ab660-a35b-4ebd-87be-5e770e370f24") },
                    { 146L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Help letter art me economic crime occur. Serve itself summer start this thing. American important key traditional audience about result.\nNational kind culture blood.\nGoal never peace possible remain.", null, true, "Monitors Management 9431", 800.08m, 15, null, null, new Guid("5842a599-5589-45b4-8d08-695b9fd536d1") },
                    { 147L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Adult center western window owner go stage. Measure suggest per tonight kind. Garden forward nearly local.\nWait north without quite specific. She right relationship protect allow.", null, true, "Monitors Move 7728", 1822.34m, 23, null, null, new Guid("10c07baf-cd3f-4837-8e4e-c69086ef16a8") },
                    { 148L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Chair future play fly there similar north. Degree who risk TV radio all. Site without adult door expect later.", null, true, "Monitors Race 6904", 1314.6m, 14, null, null, new Guid("3b0de20a-b51b-4dd1-83c4-8bc3c6af1c7d") },
                    { 149L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Quite general experience because. Fast scene so.\nDemocrat stuff quality receive. Method law mean world military guy race.\nSubject now so leader million computer. Service study charge.", null, true, "Monitors All 1348", 1513.99m, 48, null, null, new Guid("218ca05e-6dc1-45db-8282-1253a7d30ef2") },
                    { 150L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This monitors is designed for high performance in computing. Issue security marriage method. Civil economic federal spring.\nRepublican participant involve. National indicate water security.\nMy visit since food itself son. Key enter garden everybody.", null, true, "Monitors View 2793", 450.45m, 8, null, null, new Guid("6eed13aa-17fb-4643-aa39-ece9ceab18ac") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 5L);
        }
    }
}
