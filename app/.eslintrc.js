module.exports = {
  parser: "@typescript-eslint/parser",
  env: {
    es2021: true,
    browser: true,
    node: true,
  },

  parserOptions: {
    ecmaFeatures: {
      jsx: true,
    },
    ecmaVersion: 12,
    sourceType: "module",
  },
  extends: [
    "next",
    "prettier",
    "eslint:recommended",
    "plugin:@typescript-eslint/recommended",
  ],
  plugins: ["@typescript-eslint", "unicorn"],
  rules: {
    "no-console": "warn",
    "no-unused-expressions": ["error", { allowTernary: true }],
    "react/react-in-jsx-scope": "off",
    "react/jsx-no-comment-textnodes": "off",
    "react/jsx-props-no-spreading": "off",
    "react/no-array-index-key": "off",
    "react/no-unescaped-entities": "off",
    "react/prop-types": "off",
    "react/require-default-props": "off",
    "react/display-name": "off",
    "react/jsx-key": "off",
    "@typescript-eslint/no-unused-vars": "warn",
    "@typescript-eslint/consistent-type-imports": "warn",
    "no-inline-comments": "warn",
    "no-unneeded-ternary": "warn",
    "no-useless-return": "warn",
    "prefer-const": "warn",
    "no-var": "warn",
    quotes: ["warn", "double"],
    semi: "warn",
    "no-extra-semi": "warn",
    "prefer-object-spread": "warn",
    "prefer-destructuring": "warn",
    "dot-notation": "warn",
    curly: "warn",
    "default-case": "warn",
    "no-mixed-operators": "off",
    "no-iterator": "warn",
    "no-restricted-syntax": [
      "warn",
      {
        selector:
          "ImportDeclaration[source.value='react'][specifiers.0.type='ImportDefaultSpecifier']",
        message:
          'Default React import not allowed. Use import * as React from "react"',
      },
      {
        selector:
          "ImportDeclaration[source.value='react'][specifiers.0.type='ImportSpecifier']",
        message:
          'Default React import not allowed. Use import * as React from "react"',
      },
    ],
    "unicorn/filename-case": [
      "warn",
      {
        case: "kebabCase",
      },
    ],
  },
  settings: {
    react: {
      version: "detect",
    },
  },
};
