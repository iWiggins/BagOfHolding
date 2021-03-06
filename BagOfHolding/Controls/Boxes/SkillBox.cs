﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagOfHolding
{
    public partial class SkillBox : UserControl
    {
        Skill skill;

        public SkillBox() {
            skill = new Skill();
            InitializeComponent();
            updateUIData();
        }

        public SkillBox(Skill s) {
            skill = s;
            InitializeComponent();
            updateUIData();
        }

        private void updateUIData() {
            skill_name_box.Text = skill.getName();
            ability_box.Text = getAbilityString();
            total_box.Text = skill.getTotal().ToString();
            ranks_box.Value = skill.getRanks();
            ability_mod_box.Text = skill.getAbilityMod().ToString();
            if(skill.getTrained())
                trained_box.Text = "3";
            else
                trained_box.Text = "0";
            miscMod1_box.Text = skill.getMiscMod1().ToString();
            miscMod2_box.Text = skill.getMiscMod2().ToString();
            class_skill_box.Checked = skill.getClassSkill();
        }

        private string getAbilityString() {
            switch(skill.getAbilityType()) {
                case 0:
                    return "STR";
                case 1:
                    return "DEX";
                case 2:
                    return "CON";
                case 3:
                    return "INT";
                case 4:
                    return "WIS";
                case 5:
                    return "CHA";
                default:
                    return "STR";
            }
        }

        #region Get & Set methods
        public Skill getSkill() {
            return skill;
        }

        public void setSkill(Skill s) {
            skill = s;
        }

        #endregion

        #region Event Handlers
        private void skill_name_box_TextChanged(object sender, EventArgs e) {
            skill.setName(skill_name_box.Text);
        }

        private void ranks_box_ValueChanged(object sender, EventArgs e) {
            skill.setRanks((int) ranks_box.Value);
            updateUIData();
        }

        private void miscMod1_box_TextChanged(object sender, EventArgs e) {
            int m;
            if(int.TryParse(miscMod1_box.Text, out m))
                skill.setMiscMod1(m);
            else
                skill.setMiscMod1(0);

            updateUIData();
        }

        private void miscMod2_box_TextChanged(object sender, EventArgs e) {
            int m;
            if(int.TryParse(miscMod2_box.Text, out m))
                skill.setMiscMod2(m);
            else
                skill.setMiscMod2(0);

            updateUIData();
        }

        private void class_skill_box_CheckedChanged(object sender, EventArgs e) {
            skill.setClassSkill(class_skill_box.Checked);
            updateUIData();
        }
        #endregion

        private void ability_box_Leave(object sender, EventArgs e) {
            switch(ability_box.Text.ToUpper()) {
                case "STR": 
                        skill.setAbilityType(0);
                        break;
                case "DEX": 
                        skill.setAbilityType(1);
                        break;
                case "CON":
                        skill.setAbilityType(2);
                        break;
                case "INT":
                        skill.setAbilityType(3);
                        break;
                case "WIS":
                        skill.setAbilityType(4);
                        break;
                case "CHA":
                        skill.setAbilityType(5);
                        break;
                default: {
                        ability_box.Text = "STR";
                        skill.setAbilityType(0);
                        break;
                    }   
            }
        }
    }
}
